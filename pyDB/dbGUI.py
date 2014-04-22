# Database Graph GUI

import wx
import readDB
import matplotlib
matplotlib.use('WXAgg')
import matplotlib.pyplot as plt
from matplotlib.figure import Figure
from matplotlib.backends.backend_wxagg import \
    FigureCanvasWxAgg as FigCanvas, \
    NavigationToolbar2WxAgg as NavigationToolbar


class dbWindow(wx.Frame):
    
    def __init__(self, parent, title):
        super(dbWindow, self).__init__(parent, title=title, size = (600,400))
        self.reader = readDB.dbReader()
        self.widgets = []
        self.InitUI()


    def InitUI(self):
        # Create a Panel that we can put widgets in
        self.pnl = wx.Panel(self)

        # Get list of Users from database
        Users = self.reader.readNames()

        # Creates a Dropbox to select User by name
        self.cb = wx.ComboBox(self.pnl, pos=(50, 30), choices=Users, 
            style=wx.CB_READONLY)
        self.widgets.append(self.cb)


        # Bind event to take 
        self.st = wx.StaticText(self.pnl, label='', pos=(50, 140))
        self.widgets.append(self.st)
        
        self.cb.Bind(wx.EVT_COMBOBOX, self.OnSelect)

        self.btn = wx.Button(self.pnl, label='Go', pos=(475, 325))
        self.widgets.append(self.btn)

        self.btn.Bind(wx.EVT_BUTTON, self.SelectDataScreen)
        
        self.Centre()
        self.Show()
        
    # Called when user Selects a name from the first dropdown menu 
    def OnSelect(self, event):
        i = event.GetString()
        self.st.SetLabel(i)


    # Called When the User clicks Go in the first menu
    def SelectDataScreen(self, event):
        self.userName = (self.st.GetLabel())
        print(str(self.userName))
        pos = str(self.userName).find(' ')

        self.p_id = int(self.userName[0:pos])
        print(self.p_id)
        tables = self.reader.readExerciseTables(self.p_id)
        
        self.destroyAll()
        
        self.cb1 = wx.ComboBox(self.pnl, pos=(50, 300), choices=tables, 
            style=wx.CB_READONLY)
        self.widgets.append(self.cb1)
        self.cb1.Bind(wx.EVT_COMBOBOX, self.OnSelectTable)

    def OnSelectTable(self, event):
        data_points = self.reader.readTimeTables(event.GetString())
        self.cb2 = wx.ComboBox(self.pnl, pos = (150, 300), choices=data_points[0],
                               style=wx.CB_READONLY)
        self.widgets.append(self.cb2)

        
    # Destroys all widgets
    def destroyAll (self):
        for all in self.widgets:
            all.Destroy()




def main():
    app = wx.App()
    dbWindow(None, title='Exercise Data Visualizer')
    app.MainLoop()

if __name__ == '__main__':
    main()    
