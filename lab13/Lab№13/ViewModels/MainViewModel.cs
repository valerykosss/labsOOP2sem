using Lab_13.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_13.ViewModels
{
    public class MainViewModel
    {
        public ObservableCollection<ConsultationViewModel> ConsultationsList { get; set; }
        public MainViewModel(List<Consultation> consultations)
        {
            ConsultationsList = new ObservableCollection<ConsultationViewModel>(
                consultations.Select(c => new ConsultationViewModel(c)));
        }
    }
}
