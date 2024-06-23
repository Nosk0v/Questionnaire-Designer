using Database;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
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
    
    public partial class MainPage : Page
    {
        private readonly ConstructorEntities database;
        public ObservableCollection<Question> Questions { get; set; }
        public ObservableCollection<Answer> Answers { get; set; }
        public MainPage(ConstructorEntities entities)
        {
            InitializeComponent();
            
            database = entities;
            DataContext = this;
            LoadData();

            
        }
        private void LoadData()
        {
            Questions = new ObservableCollection<Question>(database.Questions);
            Answers = new ObservableCollection<Answer>(database.Answers);
        }
        private void lvQuestionnaire_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void lvQuestions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void bAddQuestion_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(ViewManager.QuestionsPage);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var question = lvQuestions.SelectedItem as Database.Question;
            database.Questions.Remove(question);
            lvQuestions.SelectedItems.Clear();
            database.SaveChanges();
            LoadData();

            
            lvQuestions.ItemsSource = Questions;
            

            MessageBox.Show("Вопрос и связанные ответы удалены.");



        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(ViewManager.QuestionnairePage);
        }
    }
}
