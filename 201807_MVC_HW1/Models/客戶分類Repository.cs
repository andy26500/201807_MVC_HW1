using System;
using System.Linq;
using System.Collections.Generic;
	
namespace _201807_MVC_HW1.Models
{   
	public  class 客戶分類Repository : EFRepository<客戶分類>, I客戶分類Repository
	{

	}

	public  interface I客戶分類Repository : IRepository<客戶分類>
	{

	}
}