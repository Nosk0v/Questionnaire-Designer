using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;

namespace Questionnaire_Designer.View
{
    internal class ViewManager
    {
        private static Database.ConstructorEntities database;
        private static MainPage mainPage;
        private static QuestionsPage questionPage;
        private static QuestionnairePage questionnairePage;
        private static Database.ConstructorEntities Database
        {
            get
            {
                if (database == null)
                {
                    database = new Database.ConstructorEntities();
                    if (database.Database.Exists() == false)
                    {
                        MessageBox.Show("Подключения к базе данных не было выполнено. Приложения будет завершено.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }

                }
                return database;
            }
        }

        public static MainPage MainPage
        {
            get
            {
                mainPage = null;
                questionPage = null;
                questionnairePage = null;
                mainPage = new MainPage(Database);
                
                return mainPage;
            }
        }
        public static QuestionsPage QuestionsPage
        {
            get
            {
                questionPage = null;
                mainPage = null;
                questionnairePage = null;
                questionPage = new QuestionsPage(Database);
                
                return questionPage;
            }
        }
        public static QuestionnairePage QuestionnairePage
        {
            get
            {
                questionnairePage = null;
                mainPage = null;
                questionPage = null;

                questionnairePage = new QuestionnairePage(Database);

                return questionnairePage;
            }
        }

    }
}
