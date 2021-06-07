import unittest
from datetime import datetime

class MainPage:

    MAIN_FILE = "Знімок екрана 2021-06-02 013407.png"
    MAIN_OPEN ="Знімок екрана 2021-06-02 011409.png"
    MAIN_SAVE = "Знімок екрана 2021-06-02 011507.png"
    MAIN_SAVE_AS = "Знімок екрана 2021-06-02 011620.png"
    
    
    def ClickOnMAIN_FILE(self):
        Sikuli.click(self.MAIN_FILE)

    def ZoomPlus(self):
        Sikuli.type(Key.ADD, KeyModifier.CTRL)
        
    def ZoomMinus(self):
        Sikuli.type(Key.MINUS, KeyModifier.CTRL)
    
    def ClickOnMAIN_OPEN(self):
        Sikuli.click(self.MAIN_OPEN)

    def ClickOnMAIN_FILE(self):
        Sikuli.click(self.MAIN_SAVE)
        
    def ClickOnMAIN_SAVE_AS(self):
        Sikuli.click(self.MAIN_SAVE_AS)
      
    def TypeText(self,text):
        Sikuli.type("a", KeyModifier.CTRL) 
        Sikuli.type(Key.BACKSPACE) 
        Sikuli.type(text);

class OpenSelectionPage:
    OPEN_SELECTION_PAGE = "Знімок екрана 2021-06-02 011719.png"

    def ClickOPEN_SELECTION_PAGE(self):
        click(self.OPEN_SELECTION_PAGE)

    def TypePath(self,text):
        
        Sikuli.type(text);

class SaveSelectionPage:
   SAVE_SELECTION_PAGE = "Знімок екрана 2021-06-02 011813.png"
   
   def ClickOnSAVE_SELECTION_PAGE(self):
        click(self.SAVE_SELECTION_PAGE)

   def TypePath(self,text):
       date_time = datetime.now().strftime("%m-%d-%Y_%H-%M-%S")
       
       
       path = text + date_time + ".txt"
       Sikuli.type(path);



class Test(unittest.TestCase):
    
    notepadApp = App("C:\\Windows\\System32\\notepad.exe")
    mainPage = MainPage()
    openSelectionPage = OpenSelectionPage()
    saveSelectionPage = SaveSelectionPage()
    
    def setUp(self):
        self.notepadApp.open()

    def testZoom(self):
        wait(1)
        self.mainPage.ZoomPlus()
   
        wait(1)
        self.mainPage.ZoomMinus()
        wait(1)
        

    def test(self):

        
        self.mainPage.ClickOnMAIN_FILE()
        self.mainPage.ClickOnMAIN_OPEN()

        wait(1)

        self.openSelectionPage.TypePath("C:\\Users\\Аня\\OneDrive\\Рабочий стол\\Lab7\\Lab7.txt")
 
        self.openSelectionPage.ClickOPEN_SELECTION_PAGE()

        self.mainPage.ClickOnMAIN_FILE()

        self.mainPage.TypeText("qwertyu")

        self.mainPage.ClickOnMAIN_FILE()
        self.mainPage.ClickOnMAIN_FILE_AS()

        wait(1)
        
        self.saveSelectionPage.TypePath("Lab7")
        self.saveSelectionPage.ClickOnSAVE_SELECTION_PAGE()

        wait(1)
        

    def tearDown(self):
        self.notepadApp.close()


if name == 'main':
    try:
      unittest.main()
    except SystemExit as inst:
        if inst.args[0] is True: 
            raise