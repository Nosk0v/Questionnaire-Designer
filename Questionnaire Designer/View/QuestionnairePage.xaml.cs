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
           
        }

        private void bInMenu_Click(object sender, RoutedEventArgs e)
        {

        }

        private void bOutMenu_Click(object sender, RoutedEventArgs e)
        {

        }

        private void GoToBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(ViewManager.MainPage);
        }

        private void lvQuestions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void lvSelectedIngridients_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {

        }

        private void tbName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
