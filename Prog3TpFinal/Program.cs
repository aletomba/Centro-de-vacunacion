using Prog3TpFinal.controlers;
using Prog3TpFinal.menu;
using Prog3TpFinal.repository;
using Prog3TpFinal.services.personService;


var repository = new Repository();
var service = new PersonService(repository);
var controller = new Controller(service);
ShowMenu showMenu = new ShowMenu(controller);
showMenu.SelectMenu();
