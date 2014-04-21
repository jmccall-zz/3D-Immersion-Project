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
        self.InitUI()

       

    def InitUI(self):
        # Create a Panel that we can put widgets in
        self.pnl = wx.Panel(self)

        # Get list of Users from database
        Users = self.reader.readNames()

        # Creates a Dropbox to select User by name
        self.cb = wx.ComboBox(self.pnl, pos=(50, 30), choices=Users, 
            style=wx.CB_READONLY)

        # Bind event to take 
        self.st = wx.StaticText(self.pnl, label='', pos=(50, 140))
        self.cb.Bind(wx.EVT_COMBOBOX, self.OnSelect)

        self.btn = wx.Button(self.pnl, label='Go', pos=(475, 325))

        self.btn.Bind(wx.EVT_BUTTON, self.SelectDataScreen)
        
        self.Centre()
        self.Show()

    def SelectDataScreen(self, event):
        self.userName = (self.st.GetLabel())
        self.destroyAll()

        self.cb = wx.ComboBox(self.pnl, pos=(50, 300), choices=["0"], 
            style=wx.CB_READONLY)

    def destroyAll (self):
        self.btn.Destroy()
        self.st.Destroy()
        self.cb.Destroy()

        
    
        
    def OnSelect(self, event):
        
        i = event.GetString()
        self.st.SetLabel(i)

def main():
    app = wx.App()
    dbWindow(None, title='Exercise Data Visualizer')
    app.MainLoop()

if __name__ == '__main__':
    main()    
