using Database;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Questionnaire_Designer.View
{
    /// <summary>
    /// Логика взаимодействия для QuestionnairePage.xaml
    /// </summary>
    public partial class QuestionnairePage : Page
    {
        private readonly ConstructorEntities database;
        public ObservableCollection<Question> Questions { get; set; }
        public ObservableCollection<Question> SelectedQuestions { get; set; }

        public QuestionnairePage(ConstructorEntities entities)
        {
            InitializeComponent();
            database = entities;
            DataContext = this;
            LoadData();
        }

        private void LoadData()
        {
            Questions = new ObservableCollection<Question>(database.Questions);
            SelectedQuestions = new ObservableCollection<Question>();
        }

        private void bInMenu_Click(object sender, RoutedEventArgs e)
        {
            var selectedQuestion = lvQuestions.SelectedItem as Database.Question;
            SelectedQuestions.Add(selectedQuestion);
           
        }

        private void bOutMenu_Click(object sender, RoutedEventArgs e)
        {
            var selectedQuestion = lvSelectQuestions.SelectedItem as Database.Question;
            SelectedQuestions.Remove(selectedQuestion);
            bInMenu.IsEnabled = true;
        }

        private void GoToBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(ViewManager.MainPage);
        }

        private void lvQuestions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            bInMenu.IsEnabled = true;
            bOutMenu.IsEnabled = false;
        }

        private void lvSelect_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {                               
            bOutMenu.IsEnabled = true;
            bInMenu.IsEnabled = false;
        }
        private void ClearForm()
        {
            lvSelectQuestions.ItemsSource = null;
            SelectedQuestions.Clear();
            tbName.Clear();
            tbdescripton.Clear();
        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            
            var name = tbName.Text;
            var description = tbdescripton.Text;
            if (name == "" || description == "")
            {
                MessageBox.Show("Заполните данные");
                return;
            }
            Form form = new Form();
            form.Name = name;
            form.Description = description;
            database.Forms.Add(form);
            database.SaveChanges();

            foreach(var questions in SelectedQuestions)
            {
                Questionnaire questionnaire = new Questionnaire();
                questionnaire.QuestionID = questions.ID;
                questionnaire.FormsID = form.ID;
                database.Questionnaires.Add(questionnaire);
                database.SaveChanges();
            }
            MessageBox.Show("Успешно сохранено!");
            ClearForm();
        }

        
    }
}
