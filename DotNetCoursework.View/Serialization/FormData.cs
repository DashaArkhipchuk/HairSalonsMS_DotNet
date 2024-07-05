using DotNetCoursework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetCoursework.View.Serialization
{
    public class FormData
    {
        public bool LoggedIn {  get; set; }
        public User? LoggedInUser { get; set; }
        public Role?  LoggedInRole { get; set; }
        public int DataGridItemsCount { get; set; }
        public int Page {  get; set; }
        public int Skip {  get; set; }
        public int Take { get; set; }

        public int SelectedTabIndex { get; set; }

        public FormData(bool loggedIn, User? loggedInUser, Role? loggedInRole, int dataGridItemsCount, int page = 0, int skip = 0, int take = 5, int selectedTabIndex = 0)
        {
            LoggedIn = loggedIn;
            LoggedInUser = loggedInUser;
            LoggedInRole = loggedInRole;
            
            DataGridItemsCount = dataGridItemsCount;
            Page = page;
            Skip = skip;
            Take = take;
            SelectedTabIndex = selectedTabIndex;
        }
    }
}
