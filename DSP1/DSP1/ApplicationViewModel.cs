using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DSP1
{
    class ApplicationViewModel : INotifyPropertyChanged
    {
        private List<Signal> selectedSignals;
        public List<Signal> SelectedSignals
        {
            get { return selectedSignals; }
            set
            {
                selectedSignals = value;
                OnPropertyChanged("SelectedSignals");
            }
        }

        private RelayCommand pageCommand;
        public RelayCommand PageCommand
        {
            get
            {
                return pageCommand ??
                    (pageCommand = new RelayCommand(num =>
                    {
                        SelectedSignals = SignalLists[Int32.Parse((string)num)];
                    }));
            }
        }

        public ObservableCollection<List<Signal>> SignalLists { get; set; }
        public ApplicationViewModel()
        {
            SignalLists = new ObservableCollection<List<Signal>>
            {
                new List<Signal>
                {
                    new Signal(1024, 6, 3, Math.PI * 2),
                    new Signal(1024, 6, 3, Math.PI / 6),
                    new Signal(1024, 6, 3, Math.PI / 2),
                    new Signal(1024, 6, 3, 0),
                    new Signal(1024, 6, 3, Math.PI * 3 / 4)
                },
                new List<Signal>()
                {
                    new Signal(1024, 8, 2, Math.PI / 4),
                    new Signal(1024, 8, 4, Math.PI / 4),
                    new Signal(1024, 8, 3, Math.PI / 4),
                    new Signal(1024, 8, 7, Math.PI / 4),
                    new Signal(1024, 8, 5, Math.PI / 4)
                },
                new List<Signal>()
                {
                    new Signal(1024, 2, 5, Math.PI / 4),
                    new Signal(1024, 2, 5, Math.PI / 4),
                    new Signal(1024, 8, 5, Math.PI / 4),
                    new Signal(1024, 3, 5, Math.PI / 4),
                    new Signal(1024, 1, 5, Math.PI / 4)
                },
                new List<Signal>()
                {
                    new Signal(1024, 2, new double[] { 1, 2, 3, 4, 5 }, new double[] { Math.PI / 6, Math.PI / 2, Math.PI / 3, Math.PI / 9, 0 })
                },
                new List<Signal>()
                {
                    new Signal(1024, 2, 8, Math.PI / 3, 0.2, false)
                },
            };
            SelectedSignals = SignalLists[0];
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}