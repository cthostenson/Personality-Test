using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PersonalityQuiz
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        int score = 0;
        List<string> questions = new List<string>
        { "Do you like Facetime?", "Do you hate electricity?", "Were you born in 2014, or say you belong in 2014?", "If you saw something impressive, would you respond with \"Not Bad\"?" };
        int questionNumber = 0;

        public MainPage()
        {
            InitializeComponent();
            questionLabel.Text = questions[questionNumber];
        }

        void OnSwiped(Object sender, SwipedEventArgs e)
        {
            if (e.Direction.ToString() == "Right")
            {
                qTrue();
            }
            else
            {
                qFalse();
            }
        }

        void false_button_clicked(Object sender, EventArgs args)
        {
            qFalse();
        }

        void true_button_clicked(Object sender, EventArgs args)
        {
            qTrue();
        }

        private void qTrue()
        {
            score++;
            //scoreLabel.Text = score.ToString();
            nextQuestion();
        }

        private void qFalse()
        {
            score--;
            //scoreLabel.Text = score.ToString();
            nextQuestion();
        }

        private void nextQuestion()
        {
            if (questionNumber < questions.Count() - 1)
            {
                questionNumber++;
                questionLabel.Text = questions[questionNumber];
            }
            else
            {
                falseButton.IsEnabled = false;
                trueButton.IsEnabled = false;
                if (score >= 2)
                {
                    questionLabel.Text = "You Scored: Pikachu";
                }
                else if (score >= 0)
                {
                    questionLabel.Text = "You Scored: Obama";
                }
                else if (score == 1 || score == 2)
                {
                    questionLabel.Text = "You Scored: Doge";
                }
                else if (score <= 3)
                {
                    questionLabel.Text = "You Scored: Front View Camera Dog";
                }
            }
        }

        void retake_clicked(Object sender, EventArgs args)
        {
            falseButton.IsEnabled = true;
            trueButton.IsEnabled = true;
            score = 0;
            scoreLabel.Text = score.ToString();
            questionNumber = 0;
            questionLabel.Text = questions[questionNumber];
        }

        }
}
