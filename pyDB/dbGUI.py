# Database Graph GUI

import wx
import readDB

class dbWindow(wx.Frame):

    reader = []
    
    def __init__(self, parent, title):
        super(dbWindow, self).__init__(parent, title=title, size = (600,400))
        self.reader = readDB.dbReader()
        self.InitUI()

       

    def InitUI(self):
        # Create a Panel that we can put widgets in
        pnl = wx.Panel(self)

        # Get list of Users from database
        Users = self.reader.readNames()

        # Creates a Dropbox to select User by name
        cb = wx.ComboBox(pnl, pos=(50, 30), choices=Users, 
            style=wx.CB_READONLY)

        # Bind event to take 
        self.st = wx.StaticText(pnl, label='', pos=(50, 140))
        cb.Bind(wx.EVT_COMBOBOX, self.OnSelect)

        self.Centre()
        self.Show()

    def OnSelect(self, e):
        
        i = e.GetString()
        self.st.SetLabel(i)

def main():
    app = wx.App()
    dbWindow(None, title='Exercise Data Visualizer')
    app.MainLoop()

if __name__ == '__main__':
    main()    
