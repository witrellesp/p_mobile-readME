using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http.Json;

namespace p_mobile2.ViewModels
{
    public class LibraryViewModel : INotifyPropertyChanged
    {
        private HttpClient _httpClient;
        public ObservableCollection<Book> Books { get; set; } = new ObservableCollection<Book>();

        
        public ObservableCollection<Book> FavouriteBooks { get; } = new ObservableCollection<Book>();
        public ObservableCollection<Book> BestSellers { get; } = new ObservableCollection<Book>();
        public ObservableCollection<Book> RecentBooks { get; } = new ObservableCollection<Book>();


        public LibraryViewModel()
        {
            LoadBooks();
            LoadBooksAsync();
        }

        public LibraryViewModel(HttpClient httpClient)
        {
            LoadBooks();
            _httpClient = httpClient;
            LoadBooksAsync();
        }

        private async void LoadBooksAsync()
        {
            try
            {
                // Asegúrate de usar la URL correcta aquí
                var books = await _httpClient.GetFromJsonAsync<List<Book>>("http://10.0.2.2:3000/api/books/"); 
                if (books != null)
                {
                    Books.Clear();
                    foreach (var book in books)
                    {
                        Books.Add(book);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur " + ex.Message);
            }
        }




        
        private void LoadBooks()
        {
          
            FavouriteBooks.Add(new Book { Title = "Soul", CoverImage = "soul.jpg", Genre = "Fiction", Language = "English", Length = 300, Content = "Sample content..." });
            FavouriteBooks.Add(new Book { Title = "Soul", CoverImage = "soul.jpg", Genre = "Fiction", Language = "English", Length = 300, Content = "Sample content..." });
            FavouriteBooks.Add(new Book { Title = "Soul", CoverImage = "soul.jpg", Genre = "Fiction", Language = "English", Length = 300, Content = "Sample content..." });

            BestSellers.Add(new Book { Title = "Culture Map", CoverImage = "culture_map.jpg", Genre = "Non-fiction", Language = "English", Length = 200, Content = "Sample content..." });
            BestSellers.Add(new Book { Title = "Culture Map", CoverImage = "culture_map.jpg", Genre = "Non-fiction", Language = "English", Length = 200, Content = "Sample content..." });
            BestSellers.Add(new Book { Title = "Culture Map", CoverImage = "culture_map.jpg", Genre = "Non-fiction", Language = "English", Length = 200, Content = "Sample content..." });


            RecentBooks.Add(new Book { Title = "Spirit Run", CoverImage = "spirit_run.jpg", Genre = "Fiction", Language = "English", Length = 250, Content = "Sample content..." });
            RecentBooks.Add(new Book { Title = "Spirit Run", CoverImage = "spirit_run.jpg", Genre = "Fiction", Language = "English", Length = 250, Content = "Sample content..." });
            RecentBooks.Add(new Book { Title = "Spirit Run", CoverImage = "spirit_run.jpg", Genre = "Fiction", Language = "English", Length = 250, Content = "Sample content..." });
        }

        
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }





    }




}
