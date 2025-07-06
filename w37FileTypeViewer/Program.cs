using System;
using System.IO;
using System.Windows.Forms; // These 'using' directives must be at the very top of the file

namespace W37FileViewer // Ensure this namespace matches your project's default namespace
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Create an instance of your main form (Form1).
            Form1 mainForm = new Form1();

            // NOTE: InitializeComponent() IS NOT CALLED HERE. It belongs to Form1.cs.

            // Check if any command-line arguments were passed to the application.
            // When a file is opened with your app, its path will be passed as the first argument.
            if (args.Length > 0)
            {
                string filePath = args[0]; // Get the first argument, which is expected to be the file path.

                // Verify if the file actually exists at the specified path.
                if (File.Exists(filePath))
                {
                    // If the file exists, set the 'FileToLoad' property of the form.
                    // The form will then read and display this file's content when it loads.
                    mainForm.FileToLoad = filePath;
                }
                else
                {
                    // If the file does not exist, show a warning message to the user.
                    MessageBox.Show($"The specified file does not exist:\n{filePath}",
                                    "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            // Run the application, starting with the main form.
            Application.Run(mainForm);
        }
    }
}