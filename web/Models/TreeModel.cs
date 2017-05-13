using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class TreeModel
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private int pid;

        public int Pid
        {
            get { return pid; }
            set { pid = value; }
        }
        private string text;

        public string Text
        {
            get { return text; }
            set { text = value; }
        }
        public bool ischecked { get; set; }

        public string dirValue { get; set; }

    }
}