namespace coreapi.BusinessObjects.Types
{
    public enum InvoiceType
    {
        //Татан авалт
        Purchase = 0,
        //Борлуулалт
        Sale = 1,
        //Хорогдол
        Less = 2,
        //Хөдөлгөөн
        Movement = 3,
        //Тооллого
        Count = 4,
        //Сольсон-БО
        SaleChange = 5,
        //Сольсон-ХӨ
        ItemMovementChange = 6,
        //Зээл төлөлт
        CustomerPayment = 7,
        //Тооллогоор (+)
        IncomeByCount = 8,
        //Тооллогоор (-)
        OutcomeByCount = 9,
        //Борлуулалт - Зээл
        SaleLoan = 10
    }

}
