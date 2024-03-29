﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrackerLibrary;
using TrackerLibrary.Models;

namespace TrackerUI
{
    public partial class TournamentDashboardForm : Form
    {
        List<TournamentModel> tournaments = GlobalConfig.Connection.GetTournament_All();
        TournamentStatus tournamentStatus = new TournamentStatus(false);
        public TournamentDashboardForm()
        {
            InitializeComponent();
            WireUpLists();
        }
        private void WireUpLists()
        {
            loadExistingTournamentComboBox.DataSource = tournaments;
            loadExistingTournamentComboBox.DisplayMember = "TournamentName";
        }

        private void createTournamentButton_Click(object sender, EventArgs e)
        {
            
            CreateTournamentForm frm = new CreateTournamentForm(tournamentStatus);
            frm.Show();
                
        }

        private void loadTournamentButton_Click(object sender, EventArgs e)
        {
            TournamentModel tm = (TournamentModel)loadExistingTournamentComboBox.SelectedItem;
            TournamentViewerForm frm = new TournamentViewerForm(tm);
            frm.Show();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (tournamentStatus.IsCreated())
            {
                tournaments = GlobalConfig.Connection.GetTournament_All();
                WireUpLists();
            }
        }
    }
}
