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
    public partial class QuestionsPage : Page
    {
        private readonly Database.ConstructorEntities database;
        public ObservableCollection<QuestionType> QuestionType { get; set; }

        public ObservableCollection<Question> Questions { get; set; }
        public QuestionsPage(ConstructorEntities entities)
        {
            InitializeComponent();
            database = entities;
            DataContext = this;
            UpdateTypeQuestions();
        }
        private void UpdateTypeQuestions()
        {
            QuestionType = new ObservableCollection<QuestionType>(database.QuestionTypes);

        }
        private void GoToBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(ViewManager.MainPage);
        }

        

        private void cbQuestionType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbQuestionType.SelectedItem == null)
            {
                return;
            }

            spInputField.Visibility = Visibility.Collapsed;
            spAnswerOptions.Visibility = Visibility.Collapsed;

            var selectType = cbQuestionType.SelectedItem as QuestionType;
            if (selectType == null)
            {
                return;
            }
            if (selectType.Name == "Ввести")
            {
                spInputField.Visibility = Visibility.Visible;
            }
            else if (selectType.Name == "Выбор из нескольких")
            {
                spAnswerOptions.Visibility = Visibility.Visible;
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            var description = tbDescription.Text;
            var questionType = cbQuestionType.SelectedItem as QuestionType;
            if (questionType == null || description == "") 
            {
                MessageBox.Show("Заполните поля!");
                return;
            }
            Question question = new Question();
            question.Description = description;
            question.QuestionType = questionType.ID;
            database.Questions.Add(question);
            database.SaveChanges();

            if (questionType.Name == "Ввести")
            {
                MessageBox.Show("Сохранено");
                ResetFieldsAndRefreshPage();
                return;
            }

            else if (questionType.Name == "Выбор из нескольких")
            {
                var options = new[] { Option1TextBox.Text, Option2TextBox.Text, Option3TextBox.Text, Option4TextBox.Text };

                if (options.Any(string.IsNullOrWhiteSpace))
                {
                    MessageBox.Show("Заполните все варианты ответов!");
                    return;
                }

                foreach (var option in options)
                {
                    var answer = new Answer { Answer1 = option, QuestionID = question.ID};
                    database.Answers.Add(answer);
                }

                database.SaveChanges();
                ResetFieldsAndRefreshPage();
                MessageBox.Show("Сохранено");
                return;
            }
        }
        private void ResetFieldsAndRefreshPage()
        {
            
            tbDescription.Text = string.Empty;
            Option1TextBox.Text = string.Empty;
            Option2TextBox.Text = string.Empty;
            Option3TextBox.Text = string.Empty;
            Option4TextBox.Text = string.Empty;

            
            spInputField.Visibility = Visibility.Collapsed;
            spAnswerOptions.Visibility = Visibility.Collapsed;

            
            UpdateTypeQuestions();

            
            DataContext = null;
            DataContext = this;

            
            cbQuestionType.SelectedItem = null;
        }
    }
}
