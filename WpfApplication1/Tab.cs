using Prism.Mvvm;

namespace WpfApplication1
{
    public class Tab : BindableBase
    {
        public Tab(string name, string text)
        {
            this.name = name;
            this.text = text;
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }
        }
        private string text;
        public string Text
        {
            get { return text; }
            set { SetProperty(ref text, value); }
        }
    }
}