using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace APIRest_Forms
{
	public partial class MainPage : ContentPage
	{
        private const string Url = "http://jsonplaceholder.typicode.com/posts";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<Model_Post> _post;
        public MainPage()
		{
			InitializeComponent();
		}
        protected override async void OnAppearing()
        {
            string content = await client.GetStringAsync(Url);
            List<Model_Post> posts = JsonConvert.DeserializeObject<List<Model_Post>>(content);
            _post = new ObservableCollection<Model_Post>(posts);
            MyListView.ItemsSource = _post;
            base.OnAppearing();
        }
    }
}
