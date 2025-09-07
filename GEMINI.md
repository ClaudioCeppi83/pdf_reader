# Guía de Contexto para Gemini Code Assistant

## Resumen del Proyecto
Este proyecto es un lector de archivos PDF básico (MVP) para el sistema operativo **Windows**.  
El objetivo principal es abrir y navegar por un documento PDF.

## Stack Tecnológico
- **Lenguaje de Programación:** C#  
- **Framework UI:** Windows Presentation Foundation (WPF), utilizando XAML para la interfaz.  
- **Librería de Terceros:** PdfiumViewer, instalada a través de NuGet.  

## Arquitectura
- **Patrón:** Model-View-ViewModel (MVVM).  

**Componentes:**
- **View (Vista):** Archivos `.xaml` que definen la UI (botón para abrir, botones de navegación, indicador de página).  
- **ViewModel (Modelo de Vista):** Lógica principal para gestionar el documento y las interacciones del usuario. Contiene las propiedades y los comandos de la UI.  
- **Model (Modelo):** Representación de los datos, principalmente el objeto `PdfDocument` de la librería PdfiumViewer.  

## Funcionalidades del MVP (Ámbito del Proyecto)
La aplicación se limita a las siguientes características:  
- Apertura de archivos PDF mediante un cuadro de diálogo.  
- Visualización de una sola página del documento a la vez.  
- Navegación entre páginas (siguiente/anterior).  
- Indicador del estado de la página ("Página X de Y").  

## Próximos Pasos (Funcionalidades Futuras)
Estas son las características planificadas para futuras iteraciones del proyecto:  
- Funcionalidad de **zoom** (In/Out).  
- **Búsqueda de texto** dentro del documento.  
- **Miniaturas de páginas** para una navegación más rápida.  
- **Impresión de documentos**.  
- Capacidad de **guardar el documento**.  
- Soporte para **múltiples documentos en pestañas**.  

## Convenciones y Puntos Clave
- Sigue el patrón **MVVM** para separar la UI y la lógica.  
- La lógica de manejo de archivos, la navegación y el estado de la página residen en el **ViewModel**.  
- La interfaz de usuario debe ser simple, funcional y seguir los principios de **WPF**.  
- Considera el manejo de **errores básicos**, como notificar al usuario si el archivo seleccionado no es válido.  
- Deshabilita los botones de navegación si no hay más páginas disponibles.  
