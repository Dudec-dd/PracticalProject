using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalProject
{
    internal class EventToShow
    {
        public string Название { get; set; }
        public string Тема { get; set; }
        public string Жюри { get; set; }
        public string Организатор { get; set; }
        public string Модераторы { get; set; }
        public string Участники { get; set; }
        public string Активности { get; set; }
        public EventToShow() { }

        public EventToShow(string название, string тема, string жюри, string организатор, string модераторы, string участники, string активности)
        {
            Название = название;
            Тема = тема;
            Жюри = жюри;
            Организатор = организатор;
            Модераторы = модераторы;
            Участники = участники;
            Активности = активности;
        }
    }
}
