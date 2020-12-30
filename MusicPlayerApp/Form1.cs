using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicPlayerApp
{
    public partial class MusicPlayerApp : Form
    {
        public MusicPlayerApp()
        {
            InitializeComponent();
        }

        //Create Global Variables of String Type Arrat to save the titles or name of the tracks and path of the track
        String[] paths, files;
        private bool _dragging = false;
        private Point _start_point = new Point(0, 0);

        private void TopPanel_MouseDown(object sender, MouseEventArgs e)
        {
            //Click to allow window dragging
            _dragging = true;
            _start_point = new Point(e.X, e.Y);
        }

        private void TopPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (_dragging)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this._start_point.X, p.Y - this._start_point.Y);
            }
        }

        private void TopPanel_MouseUp(object sender, MouseEventArgs e)
        {
            _dragging = false;
        }

        private void btnSelectSongs_Click(object sender, EventArgs e)
        {
            //Code to select the song
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = true;

            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                files = ofd.SafeFileNames; //Save the names of the track in file array
                paths = ofd.FileNames; // Save the paths of the tracks in the path array
                //Display the music titles in listbox
                for (int i=0; i < files.Length; i++)
                {
                    listBoxSongs.Items.Add(files[i]); //Display songs in the list box
                }
            }
        }

        private void listBoxSongs_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Write a code to play music
            axWindowsMediaPlayerMusic.URL = paths[listBoxSongs.SelectedIndex];
        }

        private void MusicPlayerApp_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //Code to close the App
            this.Close();
        }
    }
}
