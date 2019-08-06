#include "pch.h"
#include <iostream>
#include <string>

using namespace std;

int main()
{
	struct Worker
	{
		string NameOfMen, NameOfProduct, Date; // Переменные, которые будут отвечать за Имя провдовца, названеи продукта и дату продажи 
		int How, Cost, KKD; //Количество проданных продуктов и их стоимость (по шутучно или 1 кг в зависимости от товара)
	};
	setlocale(LC_ALL, "Russian");
	cout << "Добрый день! Данная программа выводит данные по работе сотрудников ларька 'У дяди САМВЕЛА' ";
	
	Worker Ivanov;
	Ivanov.NameOfMen = "Иванов";
	Ivanov.Cost = 1280;
	Ivanov.Date = "31.12.2018";
	Ivanov.How = 5;
	Ivanov.NameOfProduct = "Коньяк 'Зоофил' ";
	Ivanov.KKD = 10012;

	cout << "В данный момент в магазине работает два продавца, введите фамилию продаваца о котором вы хотите узнать информацию" <<endl << "Ivanov" << endl <<"Petrov" << endl << "Write 1 or 2 все остальные значения будут просто выход из программы ";
	int k; 
	cin >> k; 
	if (k == 1 or k == 2)
	{
		if (k == 1)
		{
			cout << "Фамилия сотрудника: " << Ivanov.NameOfMen << endl;
			cout << "Общая касса, собранная сотрудником: " << Ivanov.KKD << "$" << endl;
			cout << "Самый дорогостоящий продукт, проданный сотрудником: " << Ivanov.NameOfProduct << endl; 
			cout << "Количество продукции: " << Ivanov.How << endl; 
			cout << "Цена товара: " << Ivanov.Cost << "$"<<endl;
			cout << "Дата продажи: " << Ivanov.Date << endl;

		}
		if (k == 2)
		{
			cout << "Уволен 01.03.2019 по причине частого отсутсвия" << "Поэтому на данный момент работает: ";

			cout << "Фамилия сотрудника: " << Ivanov.NameOfMen << endl;
			cout << "Общая касса, собранная сотрудником: " << Ivanov.KKD << "$" << endl;
			cout << "Самый дорогостоящий продукт, проданный сотрудником: " << Ivanov.NameOfProduct << endl;
			cout << "Количество продукции: " << Ivanov.How << endl;
			cout << "Цена товара: " << Ivanov.Cost << "$" << endl;
			cout << "Дата продажи: " << Ivanov.Date << endl;


		}
	}
	else
	{
		cout << endl << "Третьего не дано, ПОКА (Читсай внимательно) ";

	}


	return 0;
}
