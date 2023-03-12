using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Notepad
{
    public partial class Notepad : Form
    {
        public Notepad()
        {
            InitializeComponent();
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileToNotepad();
        }
        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            notepadTextArea.Undo();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            notepadTextArea.Copy();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            notepadTextArea.Cut();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            notepadTextArea.SelectedText = "";
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            notepadTextArea.SelectAll();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            notepadTextArea.Paste();
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveNotepadFile();
        }
        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            changeBackgroundColor();
        }
        private void backgroundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            changeFont();
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void openFileToNotepad()
        {
            List<string> notePadLines = new List<string>();
            try
            {
                if (openNotepadFile.ShowDialog() == DialogResult.OK)
                {
                    string nazwaPliku = openNotepadFile.FileName;
                    using (StreamReader sr = new StreamReader(nazwaPliku))
                    {
                        string wiersz;
                        while ((wiersz = sr.ReadLine()) != null)
                            notePadLines.Add(wiersz);
                    }
                }
                notepadTextArea.Lines = notePadLines.ToArray();
            }
            catch (Exception info)
            {
                MessageBox.Show("Błąd odczytu pliku " + info.Message);
            }
        }

        private void SaveNotepadFile()
        {
            string fileName = openNotepadFile.FileName;
            if (fileName.Length > 0) saveNotepadFile.FileName = fileName;
            if (saveNotepadFile.ShowDialog() == DialogResult.OK)
            {
                fileName = saveNotepadFile.FileName;
                using (StreamWriter sw = new StreamWriter(fileName))
                    foreach (string wiersz in notepadTextArea.Lines)
                        sw.WriteLine(wiersz);
            }
        }

        private void changeBackgroundColor()
        {
            backgroundColor.Color = notepadTextArea.BackColor;
            if (backgroundColor.ShowDialog() == DialogResult.OK)
                notepadTextArea.BackColor = colorDialog1.Color;
        }

        private void changeFont()
        {
            fontDialog.Font = notepadTextArea.Font;
            fontDialog.Color = notepadTextArea.ForeColor;
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                notepadTextArea.Font = fontDialog.Font;
                notepadTextArea.ForeColor = fontDialog.Color;
            }
        }
    }
}
