﻿using AppCode.BLL;


namespace WinFormsSchool
{
    public partial class SchoolArticleForm : Form
    {

        readonly ArticleBLL SchoolArticle;


        public SchoolArticleForm()
        {
            InitializeComponent();
            InitializeControls();
            Height = 610;
            Width = 1100;
            SchoolArticle = new ArticleBLL();
        }

        private void InitializeControls()
        {
            labelMessage.Text = string.Empty;
            labelMessage.Font = new Font(Font, FontStyle.Italic);
            labelMessage.ForeColor = Color.Red;
            pictureBoxArticle.BackColor = Color.LightGray;
        }

        internal void LoadSelectedArticle(int selectedArticleId)
        {
            try
            {
                var selectedArticle = SchoolArticle.GetArticleById(selectedArticleId);//selectedArticle Met hoofdletter?
                
                if(selectedArticle is not null)
                {
                    textboxArticleId.Text = selectedArticle.ArticleId.ToString();
                    textboxArticleName.Text = selectedArticle.ArticleName;
                    textboxArticlePrice.Text = (selectedArticle.ArticlePrice is not null) ? selectedArticle.ArticlePrice.ToString() + " €" : "Price unkown"; // rekening houden met null value
                    textBoxNumberInStock.Text = selectedArticle.NumberInStock.ToString();
                    textBoxMinimumStock.Text = selectedArticle.MinStock.ToString();
                    textBoxFragile.Text = selectedArticle.Fragile.ToString();
                    labelMessage.Text = (selectedArticle.Message is not null) ? selectedArticle.Message.ToString() : "";

                    if (Convert.ToBoolean(selectedArticle.Fragile))
                    {
                        textBoxFragile.ForeColor = Color.Red;
                    }

                    if (selectedArticle.ArticlePicture == null)
                    {
                        labelArticleFoto.Text = "No picture available";
                    }
                }
                
            }
            catch (ArgumentOutOfRangeException)
            {
                string ErrorText = "Article with ArticleId " + selectedArticleId + " doesn't exist";
                MessageBox.Show(ErrorText, "ErrorMessage", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception oEx)
            {
                string ErrorText = oEx.Message;
                MessageBox.Show(ErrorText, "ErrorMessage", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
       
    }
}