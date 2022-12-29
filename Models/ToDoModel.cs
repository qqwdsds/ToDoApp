using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Models
{
    class ToDoModel : INotifyPropertyChanged
    {

        private bool _isDone;
        private string _toDo;
        public DateTime CreationData { get; set; } = DateTime.Now;

        public bool IsDone
        {
            get { return _isDone; }
            set 
            {
                if (_isDone == value)
                    return;

                _isDone = value;
                OnPropertyChanged("isDone");
            }
        }

        public string ToDo
        {
            get { return _toDo; }
            set 
            {
                if (_toDo == value)
                    return;

                _toDo = value;
                OnPropertyChanged("toDo");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string text = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(text));
        }
    }
}
