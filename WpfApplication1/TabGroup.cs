using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using Prism.Commands;
using Prism.Mvvm;

namespace WpfApplication1
{
    public class TabGroup : BindableBase
    {
        private Random random;

        public TabGroup()
        {
            this.random = new Random();
            this.addNewTabCommand = new Lazy<DelegateCommand>(() => new DelegateCommand(AddNewTab, () => true));
            this.otherCommand = new Lazy<DelegateCommand>(() => new DelegateCommand(Method, () => Selected != null).ObservesProperty(() => Selected));
            Tabs.CollectionChanged += TabsChanged;
        }


        private void Method()
        {

        }

        private void TabsChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            var newItems = e.NewItems?.Cast<Tab>().ToList();
            if (newItems?.Any() == true)
            {
                Selected = newItems.Last();
            }
        }

        private void AddNewTab()
        {
            Tabs.Add(new Tab(GetNextName(), GetRandomContent()));
        }

        private string GetRandomContent()
        {
            return random.Next().ToString();
        }

        private int num = 0;
        private string GetNextName() => $"{num++}";

        private Tab selected;
        public Tab Selected
        {
            get { return selected; }
            set { SetProperty(ref selected, value); }
        }

        public ObservableCollection<Tab> Tabs { get; } = new ObservableCollection<Tab>();


        private readonly Lazy<DelegateCommand> addNewTabCommand;
        public DelegateCommand AddNewTabCommand => addNewTabCommand.Value;

        private readonly Lazy<DelegateCommand> otherCommand;
        public DelegateCommand OtherCommand => otherCommand.Value;
    }
}