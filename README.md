# PDF Reader (MVP)

## Project Overview
This project is a Minimum Viable Product (MVP) for a basic PDF reader application designed for **Windows** operating systems. The primary goal is to provide essential functionalities for opening and navigating PDF documents, serving as a foundational base for future enhancements.

## Features (MVP Scope)
The current version of the PDF Reader includes the following core functionalities:
*   **File Opening:** Ability to open PDF files through a file dialog.
*   **Page Display:** Displays the content of a single page of the PDF document at a time.
*   **Navigation:** Buttons to move to the next and previous pages.
*   **Page Status Indicator:** Shows the current page number and the total number of pages (e.g., "Page X of Y").

## Technology Stack
*   **Programming Language:** C#
*   **UI Framework:** Windows Presentation Foundation (WPF) - utilizing XAML for the user interface.
*   **Third-Party Library:** [PdfiumViewer](https://github.com/pvginkel/PdfiumViewer) - an open-source PDF rendering library, integrated via NuGet.

## Architecture
The application follows the **Model-View-ViewModel (MVVM)** architectural pattern to ensure a clear separation of concerns:
*   **View:** Defined in `.xaml` files, responsible for the user interface layout and controls.
*   **ViewModel:** Contains the application's logic, managing document state, user interactions, and data binding to the View.
*   **Model:** Represents the data, primarily the `PdfDocument` object from the PdfiumViewer library.

## Getting Started

### Prerequisites
To build and run this project, you will need:
*   **.NET SDK:** Download and install the latest .NET SDK from the official Microsoft website.
*   **Visual Studio Code (Recommended IDE):**
    *   **C# Dev Kit Extension:** Provides comprehensive C# development support.
    *   **XAML Extension:** Offers syntax highlighting and autocompletion for XAML.

### Installation
1.  **Clone the repository:**
    ```bash
    git clone https://github.com/ClaudioCeppi83/pdf_reader.git
    cd PDF_reader
    ```
2.  **Install PdfiumViewer:**
    The `PdfiumViewer` library is managed via NuGet. From the project's root directory, run:
    ```bash
    dotnet add package PdfiumViewer
    ```

### Running the Application
1.  **Build the project:**
    ```bash
    dotnet build
    ```
2.  **Run the application:**
    ```bash
    dotnet run
    ```
    This command will launch the WPF application window.

## Future Enhancements
The following features are planned for future iterations of the PDF Reader:
*   Zoom In/Out functionality.
*   Text search within the document.
*   Page thumbnails for quicker navigation.
*   Document printing capabilities.
*   Ability to save documents.
*   Support for multiple documents in tabs.
