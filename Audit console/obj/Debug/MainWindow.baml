   M S B A M L   `   `   `  ����  Audit console    Audit_console.MainWindow   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      T PMahApps.Metro, Version=1.2.4.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4f;Controls,http://metro.mahapps.com/winfx/xaml/controls  5      H DOrc.LogViewer, Version=2.0.0.0, Culture=neutral, PublicKeyToken=nullG COrc.Controls, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null*orchttp://www.wildgums.net.au/orc   5        � Title$  Audit console��5      $
��1024��5	      $	��720��5
       � WindowStartupLocation$ CenterScreen=�6#    � ToolTip$  ��6H    � 
ResizeMode$ CanMinimize=�6S    � SizeToContent$ WidthAndHeight=�6l    � 	Resources 5       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $ /Resources/Icons.xaml?�6%   %    5      .��5      ��  �� Padding$ 10q�6   ._�5   
   �� $��0,3,0,-3q�6   .+�5      �� .+�5      ,  &MahApps.Metro.Controls.MetroTabControl  -   5        	  Name$	 Navbar��5   +   $
��auto��6;   .@�5      �� -   5        
 ��Name$
 
TabGeneral��5      $��General��63   -  'MahApps.Metro.Controls.TabControlHelper   IsUnderlined . .��5      � -   5         �Name$ GeneralPanel��5      ���#eaf5fb$��0 30 0 0q�6J   $	��600��6\    � ColumnDefinitions 5      �� 5   "   $
��.75* �63   $	��140��6@   �� 5   "   $
��0.5* �63   �� 5    "   $
��2.5* �63   .+�5"      d� -   5         d�Name$ BtnStart��5"   +   $��0��5#   '   $	��100��5$   '   $	��100��63   $	��7 7q�5%   '   ���#c0e0f2    MetroCircleToggleButtonStyle#���   5'   '   $ 
Start/stop��5(   '   .��5+   "   �� -   5         ��Name$ TicArrow��5+   ,   $��60��5,   (   $��60��5-   (     
WhiteBrush#���  5.   (    J� OpacityMask 5/   &   !� 50   *    j� Stretch$
 Fill=�66     appbar_check !� Visual# �  51   2   53   #   54      56      5:      �� 5;      $��
PowerShell��6    � Cursor$
 Hand��62   .��5<      � ���	#FFE5E5E56   5=      5>      5@      �� 5C      .+�5E        -   5        $	 
NavbarTest��5E   +    5F       �� 
TargetType��%"   '��       �� 5G      " ��6    5H      5I      5J      � 5M       5N      �� 5O      $��* �6'   �� 5P      $��* �6'   �� 5Q      $��* �6'   5T      �� 5X      $��30��6   .+�5Y      �  5Z      �� 5[      $��* �6+   �� 5\      $��2* �6+    � RowDefinitions 5^      �� 5_      $��* �6(   65   �� 5`      $��2* �6(   66   5c      5f      �� 5g      .+�5i      ,  &Orc.LogViewer.AdvancedLogViewerControl  -   5        $��	LogViewer��5i   /      AccentColorBrush
 � ���$	��720��6Z   $	��459��6i   E ACatel.MVVM, Version=5.0.0.0, Culture=neutral, PublicKeyToken=null(  "Catel.Windows.Controls.UserControl,   %SkipSearchingForInfoBarMessageControl . 6v   5j      5o      5p      5q      