﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mps_proiect
{
    public partial class PopupForm : Form
    {
        public PopupForm()
        {
            InitializeComponent();
        }

        public string EnteredText
        {
            get
            {
                return (listOfCommands.Text);
            }
            set
            {
                listOfCommands.Text = value;
            }
        }

    }
}
