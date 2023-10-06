﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceManager.Core;
public class Transfer
{
    public int TransferID { get; set; }
    public int FromAccountID { get; set; }
    public int ToAccountID { get; set; }
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
    public string Description { get; set; } = null!;
    public DateTime Created { get; set; }
    public DateTime Updated { get; set; }
    public string UserID { get; set; } = null!;
}
