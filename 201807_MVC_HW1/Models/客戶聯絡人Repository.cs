using System;
using System.Linq;
using System.Collections.Generic;
	
namespace _201807_MVC_HW1.Models
{   
	public  class 客戶聯絡人Repository : EFRepository<客戶聯絡人>, I客戶聯絡人Repository
	{

	}

	public  interface I客戶聯絡人Repository : IRepository<客戶聯絡人>
	{

	}
}