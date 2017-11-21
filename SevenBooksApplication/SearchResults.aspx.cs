﻿using SevenBooksApplication.App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace SevenBooksApplication
{
    public partial class SearchResults : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!(string.IsNullOrEmpty(Request.QueryString["Term"])) && !(string.IsNullOrEmpty(Request.QueryString["Term"]))){
                    string searchTerm = Request.QueryString["Term"];
                    string searchBy = Request.QueryString["SearchBy"];

                    switch (searchBy)
                    {
                        case "Title":
                            repBookListSearch.DataSource = BusinessLogic.SearchBookByTitle(searchTerm);
                            break;
                        case "ISBN":
                            repBookListSearch.DataSource = BusinessLogic.SearchBookByISBNList(searchTerm);
                            break;
                        case "Category":
                            repBookListSearch.DataSource = BusinessLogic.SearchBookByCategory(searchTerm);
                            break;
                        default:
                            repBookListSearch.DataSource = BusinessLogic.SearchBookByTitle(searchTerm);
                            break;                                                  
                    }
                }else
                {
                    Server.Transfer("~/Default.aspx");
                }
                repBookListSearch.DataBind();
            }

        }
    }
}