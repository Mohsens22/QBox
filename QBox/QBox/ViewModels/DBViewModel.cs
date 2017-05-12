using QBox.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QBox.ViewModels
{
    public class DBViewModel : INotifyPropertyChanged
    {
        public MyCommand AddDars
        {
            get;
            set;
        }
        public MyCommand AddQ
        {
            get;
            set;
        }
        public DBViewModel()
        {
            Courses = new ObservableCollection<Model.Course>();
            Questions = new ObservableCollection<Model.Question>();
            var x =Model.SetNewQuestions.GetCourse(3);
            var y = Model.SetNewQuestions.GetQuestion(3);
            foreach (var item in x)
            {
                Courses.Add(item);
            }
            foreach (var item in y)
            {
                Questions.Add(item);
            }

            AddDars = new MyCommand();
            AddDars.CanExecuteFunc = obj => true;
            AddDars.ExecuteFunc = AddDarsAsync;
            AddQ = new MyCommand();
            AddQ.CanExecuteFunc = obj => true;
            AddQ.ExecuteFunc = AddQAsync;
        }

        private void AddQAsync(object obj)
        {
            Model.SetNewQuestions.SetQuestion(
                new Model.Question()
                {
                    Soal = Ques,
                    Answer = new List<Model.Answer>()
                    {
                    new Model.Answer() {AssignedFlag=1,Javab=A1 },
                    new Model.Answer() {AssignedFlag=2,Javab=A2 },
                    new Model.Answer() {AssignedFlag=3,Javab=A3 },
                    new Model.Answer() {AssignedFlag=4,Javab=A4 }
                    },
                    Course = Courses.FirstOrDefault(),
                    Correct = Sahih
            
                    
                }
            );
        }

        private void AddDarsAsync(object obj)
        {
            Model.SetNewQuestions.SetCourse(new Model.Course() { Name = Dars });
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private string _ques;
        private string _A1;
        private string _A2;
        private string _A3;
        private string _A4;
        private int _sahih;
        private string _dars;
        public string Dars
        {
            get
            {
                return _dars;

            }
            set
            {

                if (_dars != value)
                {
                    _dars = value;
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this,
                            new PropertyChangedEventArgs("Dars"));
                    }
                }
            }
        }

        public string Ques
        {
            get
            {
                return _ques;

            }
            set
            {

                if (_ques != value)
                {
                    _ques = value;
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this,
                            new PropertyChangedEventArgs("Ques"));
                    }
                }
            }
        }
        public string A1
        {
            get
            {
                return _A1;

            }
            set
            {

                if (_A1 != value)
                {
                    _A1 = value;
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this,
                            new PropertyChangedEventArgs("A1"));
                    }
                }
            }
        }
        public string A2
        {
            get
            {
                return _A2;

            }
            set
            {

                if (_A2 != value)
                {
                    _A2 = value;
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this,
                            new PropertyChangedEventArgs("A2"));
                    }
                }
            }
        }
        public string A3
        {
            get
            {
                return _A3;

            }
            set
            {

                if (_A3 != value)
                {
                    _A3 = value;
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this,
                            new PropertyChangedEventArgs("A3"));
                    }
                }
            }
        }
        public string A4
        {
            get
            {
                return _A4;

            }
            set
            {

                if (_A4 != value)
                {
                    _A4 = value;
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this,
                            new PropertyChangedEventArgs("A4"));
                    }
                }
            }
        }
        public int Sahih
        {
            get
            {
                return _sahih;

            }
            set
            {

                if (_sahih != value)
                {
                    _sahih = value;
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this,
                            new PropertyChangedEventArgs("Sahih"));
                    }
                }
            }
        }

        public ObservableCollection<Model.Course> Courses { get; set; }
        public ObservableCollection<Model.Question> Questions { get; set; }



    }
}
