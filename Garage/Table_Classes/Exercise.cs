using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public class Exercise
    {
        private int IdExercise;
        private string ExerciseName;
        private int WorkStation;
        private byte[] Picture;

        public int idexercise
        {
            get { return IdExercise; }
            set { IdExercise = value; }
        }
        public string exerciseName
        {
            get { return ExerciseName; }
            set { ExerciseName = value; }
        }

        public int workstation
        {
            get { return WorkStation; }
            set { WorkStation = value; }
        }

        public byte[] picture
        {
            get { return Picture; }
            set { Picture = value; }
        }

    }
}
