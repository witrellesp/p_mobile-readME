namespace p_mobile2
{
    public partial class MainPage : ContentPage
    {
        

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            
        }
        public void OnCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var book = e.CurrentSelection.FirstOrDefault() as Book;
            if (book != null)
            {
                Navigation.PushAsync(new BookDetailPage(book));
            }
        }


    }

}
