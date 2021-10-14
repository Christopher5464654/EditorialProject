namespace EditorialProject.UIForms.Infraestructure
{
    using EditorialProject.UIForms.ViewModels;
    public class InstanceLocator
    {
        public MainViewModel Main { get; set; }

        public InstanceLocator()
        {
            this.Main = new MainViewModel();
        }
    }
}