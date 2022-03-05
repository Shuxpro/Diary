﻿using DiaryPetProject.Models.VIews;
using DiaryPetProject.Privitives.Enums;
using System;
using System.Collections.Generic;

namespace DiaryProject.Views
{
    public class BaseMenuView : BaseView
    {
        private readonly List<ProgramModeModel> programModeModelList;

        private int _currentKeyMode = 0;
        private const int LastIndexMode = 6;
        private const int FirstIndexMode = 0;

        public BaseMenuView(bool appStart)
        {
            if (!appStart)
                throw new Exception(message: $"{ToString()} создался до того, как запустился проект");

            programModeModelList = new List<ProgramModeModel>();

            TestProgramList();

            ShowMenu();
        }


        private int CurrentKeyMode 
        {
            get => _currentKeyMode; 
            set 
            {
                if (value < FirstIndexMode)
                {
                    _currentKeyMode = LastIndexMode;
                    return;
                }

                if (value > LastIndexMode)
                {
                    _currentKeyMode = FirstIndexMode;
                    return;
                }

                _currentKeyMode = value;
            }
        }


        private void ShowMenu()
        {
            OutputMenu();
            GetMenuMode();
        }

        private void OutputMenu()
        {
            Console.Clear();
            ShowMessage("Режимы работы ежедневника:\n");

            foreach (ProgramModeModel item in programModeModelList)
            {
                if (MainMenuMode.Exite == item.Mode)
                    ShowMessage("\n");

                if (CurrentKeyMode == (int)item.Mode)
                {
                    ShowMessage(item.MessageText+"   < ---", ConsoleColor.Red);
                    continue;
                }

                ShowMessage(item.MessageText);
            }
        }

        private void GetMenuMode()
        {
            ConsoleKeyInfo keyPushed;
            bool flagEnter = true;

            do
            {
                keyPushed = Console.ReadKey();
                UpdateKeyMode(keyPushed);

                if (keyPushed.Key == ConsoleKey.Enter)
                    flagEnter = false;

            } while (flagEnter);


        }

        private void UpdateKeyMode(ConsoleKeyInfo keyPushed)
        {
            if (keyPushed.Key == ConsoleKey.DownArrow)
                CurrentKeyMode++;

            if (keyPushed.Key == ConsoleKey.UpArrow)
                CurrentKeyMode--;

            OutputMenu();
            GetProgrameMode();
        }

        private void GetProgrameMode()
        {
            /*switch(CurrentKeyMode)
            { case 0:

            }*/
        }

        // Тестовые данные               --             ----                   ---

        private void TestProgramList()
        {
            ProgramModeModel programModeModel = new ProgramModeModel();

            programModeModel.Mode = MainMenuMode.AddEvent;
            programModeModel.MessageText = ("Добавить ивент, его дату и время проведения");
            programModeModelList.Add(programModeModel);

            ProgramModeModel programModeModel1 = new ProgramModeModel();
            programModeModel1.Mode = MainMenuMode.Changed;
            programModeModel1.MessageText = ("Изменить ивент, его дату и время проведения");
            programModeModelList.Add(programModeModel1);

            ProgramModeModel programModeModel2 = new ProgramModeModel();
            programModeModel2.Mode = MainMenuMode.DeleteEvent;
            programModeModel2.MessageText = ("Удалить ивент, его дату и время проведения");
            programModeModelList.Add(programModeModel2);

            ProgramModeModel programModeModel3 = new ProgramModeModel();
            programModeModel3.Mode = MainMenuMode.WatchEvents;
            programModeModel3.MessageText = ("Посмотреть расписание ивентов, их дату и время проведения");
            programModeModelList.Add(programModeModel3);

            ProgramModeModel programModeModel4 = new ProgramModeModel();
            programModeModel4.Mode = MainMenuMode.AddPushForEvent;
            programModeModel4.MessageText = ("Добавить время уведомления ивента");
            programModeModelList.Add(programModeModel4);

            ProgramModeModel programModeModel5 = new ProgramModeModel();
            programModeModel5.Mode = MainMenuMode.ExportEvent;
            programModeModel5.MessageText = ("Экспортировать расписание дня в файл");
            programModeModelList.Add(programModeModel5);

            ProgramModeModel programModeModel6 = new ProgramModeModel();
            programModeModel6.Mode = MainMenuMode.Exite;
            programModeModel6.MessageText = ("Выход из ежедневника");
            programModeModelList.Add(programModeModel6);
        }
    }
}