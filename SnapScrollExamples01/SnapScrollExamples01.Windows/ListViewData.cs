using SnapScrollExamples01.Annotations;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SnapScrollExamples01
{
    public class Item : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        private string _title = string.Empty;
        public string Title
        {
            get { return _title; }
            set
            {
                if (_title != value)
                {
                    _title = value;
                    OnPropertyChanged();
                }
            }
        }

    }

    public class ItemCollection : ObservableCollection<Object>
    {
        private ObservableCollection<Item> _itemCollection = new ObservableCollection<Item>();
    }

    public class ListViewData
    {
        public ListViewData()
        {
            string[] names =
            {
                "First", "Second", "Third", "Fourth", "Fifth", "Sixth", "Seventh", "Eighth", "Nineth",
                "Tenth"
            };
            for (int i = 0; i < 10; i++)
            {
                var name = i < names.Length ? names[i] : "default";
                var item = new Item {Title = name};
                Collection.Add(item);
            }


        }

        private readonly ItemCollection _collection = new ItemCollection();

        public ItemCollection Collection
        {
            get
            {
                return _collection;
            }
        }
    }

   
}
