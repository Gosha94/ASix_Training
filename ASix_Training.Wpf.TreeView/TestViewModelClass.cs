using PropertyChanged;
using System.ComponentModel;
using System.Threading.Tasks;

namespace ASix_Training.Wpf.TreeView
{
    // NuGet Fody можно убирать OnPropertyChanged из свойств ViewModel, все публичные св-ва автоматически уведомляют View
    [AddINotifyPropertyChangedInterface]
    class TestViewModelClass : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        public TestViewModelClass()
        {
            // 5 раз в секунду обновляем свойство с текстом для кнопки, в другом потоке
            Task.Run(async () =>
            {
                int i = 0;

                while (true)
                {
                    await Task.Delay(200);
                    Test = (i++).ToString();                    
                }
            });
        }
        public string Test { get; set; }        

        public override string ToString()
        {
            return "Hello Button";
        }
    }
}
