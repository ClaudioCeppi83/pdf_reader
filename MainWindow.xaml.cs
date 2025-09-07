
using Microsoft.Win32;
using PdfiumViewer;
using System.IO;
using System.Windows;
using System.Windows.Forms;

namespace PDF_reader
{
    public partial class MainWindow : Window
    {
        private PdfDocument _pdfDocument;
        private int _currentPage;
        private readonly PdfRenderer _pdfRenderer;

        public MainWindow()
        {
            InitializeComponent();
            _pdfRenderer = new PdfRenderer();
            WindowsFormsHost.Child = _pdfRenderer;
        }

        private void OpenFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "PDF Files (*.pdf)|*.pdf"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                _pdfDocument = PdfDocument.Load(openFileDialog.FileName);
                _pdfRenderer.Load(_pdfDocument);
                _currentPage = 0;
                ShowPage();
            }
        }

        private void PreviousPage_Click(object sender, RoutedEventArgs e)
        {
            if (_pdfDocument != null && _currentPage > 0)
            {
                _currentPage--;
                ShowPage();
            }
        }

        private void NextPage_Click(object sender, RoutedEventArgs e)
        {
            if (_pdfDocument != null && _currentPage < _pdfDocument.PageCount - 1)
            {
                _currentPage++;
                ShowPage();
            }
        }

        private void ShowPage()
        {
            if (_pdfDocument != null)
            {
                _pdfRenderer.Render(_currentPage, PageRotate.None);
                PageInfo.Text = $"Página {_currentPage + 1} de {_pdfDocument.PageCount}";
            }
        }
    }
}
