   M S B A M L   `   `   `  ����E  APSterminal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:PSterminal
PSterminal  5   	   X TXceed.Wpf.Toolkit, Version=2.5.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f4P:clr-namespace:Xceed.Wpf.Toolkit;assembly=Xceed.Wpf.ToolkitXceed.Wpf.Toolkit 5   	       PSterminal.SettingsWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:PSterminal     5   	   NwpfTool:clr-namespace:Xceed.Wpf.Toolkit;assembly=Xceed.Wpf.Toolkit     5   	   -   5          �Name$  
settingWin��5   	    � Title$ SettingsWindow��5
   	   $	��480��6    $	��450��6-    � 	Resources 5         ButtonStyle �� 
TargetType �� Property �� Value  ButtonTemplate �� 
TargetType ��Name ��Name	 �� Triggers
 P� Property P� Value �� 
TargetName��%g  &	        &	 �     7   �� 5   
   " ��6$   .�5      ��  � ��$ 0q�60   �� 5       � ��
 ���� 6+   �� 5       � ��$ 25��6'   �� 5       � ��$ 45��6&   5      �� 5   
   " ��61   .R�5      �� $ ButtonBorder��6   8��  ._�5      �� $ ContentPresenter��6#   ��. $��Center=�6X   $��Center=�6u   5      	 5      P� 5      
 �@J�IsMouseOver . . �5      �� $ ButtonBorder��6    � ��$ 1q�6R   �� 5      $ ButtonBorder��6    � �� �	#FFA8A8A86M   �� 5      $ ContentPresenter��6    � ��
 �   �6[   5      P� 5      
 � �� . . �5      �� $ ButtonBorder��6    � ��
 �����6M   �� 5       $ ButtonBorder��6    � ��
 �����6N   �� 5!      $ ContentPresenter��6    � ��
 �   �6[   5"      5$      5%      .��5&      � -   5         �Name$ MainGrid��5&      ��6   �� *	MainColor+ � RowDefinitions 5'   
   �� 5(      �� 5)      �� 5*      �� 5+      $��35 �6   .+�5-   
   �� $��1q�6   
�������$��5q�68   ._�5.      �  5/      �� 50      $��26 �6$   �� 51      �� 52      .+�54      �� $��Style��6   $��0��6N   ��6(   �� *FontForeground+6N   �� 55      $��1��6    �� Orientation$ 
Horizontal=�6*   .+�56      � $��35��6   	� 57      -   5        $��rbLightStyle��57   "    	� 	GroupName$ group��66   $��
Light Side��6H   ��6]   �� *FontForeground+6�   58      �� 59      $��2��6   $ 
Horizontal=�6*   .+�5:      � $��35��6   	� 5;      -   5        $��
rbDarkSide��5;   "   $ group��64   $��	Dark Side��6F   ��6Z   �� *FontForeground+6�   5<      5=      5>      �� 5?   
   $��1q�6   
�������$��5q�68   $��1��6C   ._�5@      �  5A      �� 5B      �� 5C       � ColumnDefinitions 5E      �� 5F      �� 5G      �� 5H      .+�5J      �� $��Center=�6   $��Center=�6[   $��Command Highlight��6v   $��0��6�   $��0��6�   ��65   �� *FontForeground+6�   #  Xceed.Wpf.Toolkit.ColorPicker  5K      -   5          Name$ dtpCommnadHighlight��5K   �   $��25��6�   $��10,15,10,15q�6�   $��0��6�   $��1��6�      SelectedColor 6&   �� *CommandHighlight+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5L      -   5         ��Name$ 	tbCommnad��5L      $��0��61   $��2��6>   $��25��6N   $��7,0,7,0q�6Z   ��6k   �� *InputTextBoxBrush+ �5M      /� 5N      .T�5O      J� .*�6(   Text5Q      5R      5T      �� 5V      $��Center=�6   $��Center=�6[   $��Parameter Highlight��6v   $��1��6�   $��0��6�   ��65   �� *FontForeground+6�     5W      -   5        $ dtpParameterHighlight��5W   �   $��25��6�   $��10,15,10,15q�6�   $��1��6�   $��1��6�    6&   �� *ParameterHighlight+$ TwoWay=�$ PropertyChanged=�6�   �� 5X      -   5        $ tbParameter��5X      $��1��63   $��2��6@   $��25��6P   $��7,0,7,0q�6\   ��6m   �� *InputTextBoxBrush+ �5Y      /� 5Z      .T�5[      J� .*�6(   Text5]      5^      5`      5a      5b      �� 5c   
   $��2��6   $��1q�6   
�������$��5q�6E   ._�5d      �  5e      �� 5f      �� 5g      �� 5h      �� 5i       5k      �� 5l      �� 5m      .+�5o      �� $��Script Background��6   $��0��6Z   $��0��6j   $��Center=�6w   ��64   �� *FontForeground+6w   �� 5p      $��Output Background��6   $��0��6Z   $��1��6j   $��Center=�6w   ��64   �� *FontForeground+6w   �� 5q      $��	Font Size��6   $��0��6R   $��2��6b   $��Center=�6o   ��6,   �� *FontForeground+6o   �� 5r      $��
Font Color��6   $��0��6S   $��3��6c   $��Center=�6p   ��6-   �� *FontForeground+6p     5s      -	   5        $��ScriptColor��5s   �   $��	15,3,15,3q�6�   $��0��6�   $��1��6�    6&   �� *InputTextBoxBrush.Color+$ TwoWay=�$ PropertyChanged=�6�     5t      -
   5        $��OutputColor��5t   �   $��	15,3,15,3q�6�   $��1��6�   $��1��6�    6&   �� *OutputTextBoxBrush.Color+$ TwoWay=�$ PropertyChanged=�6�   �� 5u      -   5        $��FontSize��5u      $
��Left=�6*   $��15,2,0,1q�6�   $��22��6�   $��40��6�   $��2��6�   $��1��6�   ��6E   �� *
SizeOfFont+$ TwoWay=�$ PropertyChanged=�6�     5v      -   5        $��	FontColor��5v   �   $��	15,3,15,3q�6�   $��3��6�   $��1��6�    6&   �� *UserFontForeground.Color+$ TwoWay=�$ PropertyChanged=�6�   5w      5x      �� 5y   
   -   5        #��[ 5y      $��3��6b   $��25��6o   $��50��6{   $
��Save��6�   ��6<   �� *FontForeground+6�   5z      5{      