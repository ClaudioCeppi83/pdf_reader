using Microsoft.Win32;
using PdfiumViewer;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace PDF_reader
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private PdfDocument? _document;
        private int _currentPage;
        private BitmapSource? _pdfPageImage;

        public BitmapSource? PdfPageImage
        {
            get => _pdfPageImage;
            set
            {
                _pdfPageImage = value;
                OnPropertyChanged();
            }
        }

        public int CurrentPage
        {
            get => _currentPage;
            set
            {
                _currentPage = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(PageInfo));
            }
        }

        public int PageCount => _document?.PageCount ?? 0;

        public string PageInfo => $"Página {CurrentPage} de {PageCount}";

        public ICommand OpenCommand { get; }
        public ICommand NextPageCommand { get; }
        public ICommand PreviousPageCommand { get; }

        public MainViewModel()
        {
            OpenCommand = new RelayCommand(OpenFile);
            NextPageCommand = new RelayCommand(NextPage, CanGoToNextPage);
            PreviousPageCommand = new RelayCommand(PreviousPage, CanGoToPreviousPage);
        }

        private void OpenFile(object? parameter)
        {
            var dialog = new OpenFileDialog
            {
                Filter = "PDF Files (*.pdf)|*.pdf",
                DefaultExt = ".pdf"
            };

            if (dialog.ShowDialog() == true)
            {
                _document = PdfDocument.Load(dialog.FileName);
                CurrentPage = 1;
                RenderPage();
            }
        }

        private void NextPage(object? parameter)
        {
            if (CanGoToNextPage(parameter))
            {
                CurrentPage++;
                RenderPage();
            }
        }

        private bool CanGoToNextPage(object? parameter)
        {
            return _document != null && CurrentPage < PageCount;
        }

        private void PreviousPage(object? parameter)
        {
            if (CanGoToPreviousPage(parameter))
            {
                CurrentPage--;
                RenderPage();
            }
        }

        private bool CanGoToPreviousPage(object? parameter)
        {
            return _document != null && CurrentPage > 1;
        }

        private void RenderPage()
        {
            if (_document == null)
                return;

            using (Image image = _document.Render(CurrentPage - 1, 96, 96, false))
            {
                PdfPageImage = ConvertToBitmapSource(image);
            }
        }

        private BitmapSource ConvertToBitmapSource(Image image)
        {
            using (var memoryStream = new MemoryStream())
            {
                image.Save(memoryStream, ImageFormat.Png);
                memoryStream.Position = 0;

                var bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = memoryStream;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();
                bitmapImage.Freeze();

                return bitmapImage;
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}