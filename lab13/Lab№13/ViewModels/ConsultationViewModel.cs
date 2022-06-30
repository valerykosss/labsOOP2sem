using Lab_13.Commands;
using Lab_13.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Lab_13.ViewModels
{
    public class ConsultationViewModel : ViewModelBase
    {
        public Consultation Consultation;

        public ConsultationViewModel(Consultation consultation)
        {
            Consultation = consultation;
        }

        public string Subject
        {
            get => Consultation.Subject;
            set
            {
                Consultation.Subject = value;
                OnPropertyChanged();
            }
        }

        public string Date
        {
            get => Consultation.Date;
            set
            {
                Consultation.Date = value;
                OnPropertyChanged();
            }
        }

        public string Time
        {
            get => Consultation.Time;
            set
            {
                Consultation.Time = value;
                OnPropertyChanged();
            }
        }

        public int Count
        {
            get => Consultation.Count;
            set
            {
                Consultation.Count = value;
                OnPropertyChanged();
            }
        }

        private DelegateCommand enrollCommand;
        public ICommand EnrollCommand
        {
            get
            {
                if (enrollCommand == null)
                {
                    enrollCommand = new DelegateCommand(obj => {
                        Count--;
                    }, obj => Count > 0);
                }
                return enrollCommand;
            }
        }

        private DelegateCommand cancelCommand;
        public ICommand CancelCommand
        {
            get
            {
                if (cancelCommand == null)
                {
                    cancelCommand = new DelegateCommand(obj => {
                        Count++;
                    }, obj => Count < 20);
                }
                return cancelCommand;
            }
        }
    }
}
