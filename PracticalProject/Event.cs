using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PracticalProject
{
    internal class Event
    {
        public static List<Event> Events = new List<Event>();
        public string EventName { get; set; }
        public string EventTheme { get; set; }
        public User EventJury { get; set; }
        public User EventOrg { get; set; }
        public List<User> EventModerators { get; set; } = new List<User>();
        public List<User> EventUsers { get; set; } = new List<User>();
        public List<Activity> EventActivities { get; set; } = new List<Activity>();
        public Event() { }
        public Event(string name,string theme,User jury,User org) 
        {
            EventName = name;
            EventTheme = theme;
            EventJury = jury;
            EventOrg = org;
            Events.Add(this);
        }
        
        public void AddUserToEvent(User user)
        {
            if(!EventUsers.Contains(user))
            EventUsers.Add(user);
            else
            {
                MessageBox.Show("Этот пользователь уже являетесь участником данного мероприятия!");
            }
        }
        public static Event GetEventByName(string name)
        {
            foreach(Event e in Events)
            {
                if(e.EventName == name) return e;
            }
            return null;
        }
        public void AddModeratorToEvent(User user)
        {

            if (user.role == "Moderator" && !EventModerators.Contains(user))
            {
                EventModerators.Add(user);
                MessageBox.Show("Готово!");
            }
            else
            {
                MessageBox.Show("Вы уже являетесь модератором данного мероприятия!");
            }
        }

        public void AddActivity(Activity activity) 
        {
            EventActivities.Add(activity);
        }
        public string EventActivitiesToString()
        {
            List<string> list = new List<string>();
            foreach(var activity in EventActivities)
            {
                list.Add(activity.Name.ToString());
            }
            if(list.Count > 0)
            return list.Aggregate((a, b) => a + ", " + b);
            return "";
        }
        public string EventUsersToString()
        {
            List<string> list = new List<string>();
            foreach (var activity in EventUsers)
            {
                list.Add(activity.name.ToString());
            }
            if (list.Count > 0)
                return list.Aggregate((a, b) => a + ", " + b);
            return "";
        }
        public void RemoveEvent()
        {
            Events.Remove(this);
        }
        public string EventModeratorsToString()
        {
            List<string> list = new List<string>();
            foreach (var activity in EventModerators)
            {
                list.Add(activity.name.ToString());
            }
            if (list.Count > 0)
                return list.Aggregate((a, b) => a + ", " + b);
            return "";
        }
        public static List<EventToShow> ShowEvents()
        {
            List<EventToShow> eventToShows = new List<EventToShow>();
            foreach (var item in Events)
            {
                eventToShows.Add(new EventToShow(item.EventName,item.EventTheme,item.EventJury.name,item.EventOrg.name,item.EventModeratorsToString(),item.EventUsersToString(),item.EventActivitiesToString()));
            }
            return eventToShows;
        }

    }
}
