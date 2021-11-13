CriptoPortfolio is application for manage and nonitoring cripto coins.

Multi-layer application architecture, MVVM.












Development process.

1. Add layer Domain. Inqluded models Coin and Transaction (many-to-many), IRepository, IUnitOfWork.
2. Add layer TestData (depends on Domain), inqluded test repository for Coin, for Transaction, TestUnitOfWork
3. Add layer Business(depends on Domain, TestData). Added managers for coin and transaction. Factory Method (Virtual Constructor).
4. Add references main prj -> Domain and portfolio.Business
5. Add ViewModelBase, MainWindowViewMode. Design mainWindow.
6. RelayCommand, library Behaviors.
7. Add layer DAL -  Entity Framework Core (depends Domain)
[...]
