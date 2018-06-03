using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AI2raportyMobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListViewPage1 : ContentPage
    {
        public ObservableCollection<Transaction> Items { get; set; }
        RestService _restService = new RestService();
        
        public ListViewPage1()
        {
            InitializeComponent();

           
            var list = _restService.TeamAll();


            Items = new ObservableCollection<Transaction>();
            Transaction addItem = new Transaction();
            addItem.Title = "Add new transaction";
            Items.Add(addItem);
            foreach (var transaction in list)
            {
                Items.Add(transaction);
            }


            MyListView.ItemsSource = Items;
            MyListView.Header = "Transactions: ";
        }
        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;
            
            Transaction transaction = (Transaction)e.Item;
            if(transaction.Title != "Add new transaction")
            await DisplayAlert("Transaction details: ", "Title: " + transaction.Title + Environment.NewLine + "Amount: " +transaction.Amount, "OK");
            else
            {
                var detailPage = new DetailPage();
                await Navigation.PushModalAsync(detailPage);
            }

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }
    }

    class DetailPage : ContentPage
    {
        public DetailPage()
        {
            List<Entry> entrys = new List<Entry>();

            entrys.Add(new Entry
            {
                Keyboard = Keyboard.Text,
                Placeholder = "Enter title",

            });

            entrys.Add(new Entry
            {
                Keyboard = Keyboard.Numeric,
                Placeholder = "Enter amount",

            });

            Button button = new Button
            {
                Text = "Add",
                Font = Font.SystemFontOfSize(NamedSize.Large),
                BorderWidth = 1,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
                
            };
            button.BackgroundColor = Color.Green;
            button.Clicked += OnButtonClicked;

            Label header = new Label
            {
                Text = "Add transaction",
                FontSize = 32,
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Center
            };
            header.TextColor = Color.DarkGreen;
            
            // Build the page.
            Title = "Entry";
            Padding = new Thickness(10, 0);
            Content = new StackLayout
            {
                Children =
                {
                    header,
                    entrys[0],
                    entrys[1],
                    button
  
                }
            };

            void OnButtonClicked(object sender, EventArgs e)
            {
                string title = entrys[0].Text;
                string amountText = entrys[1].Text;
                double amount = Convert.ToDouble(amountText);

                Transaction transaction = new Transaction();
                transaction.Title = title;
                transaction.Date = DateTime.Today;
                transaction.Amount = amount;
                
                RestService restService = new RestService();
                restService.SaveTransactionAsync(transaction);

                
            }

        }
        
    }
}
