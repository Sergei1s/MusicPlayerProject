   M S B A M L   `   `   `  ����F  BMusicPlayer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:MusicPlayerMusicPlayer  5          MusicPlayer.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      +localclr-namespace:MusicPlayer     5        � Title$  Ka Music PLayer��5      $	��642��6%   $	��879��62   4  .System.Windows.Automation.AutomationProperties   	AccessKey$  ��6>    � Icon$ main_icon.png��6`    � 
ResizeMode$ NoResize=�6u   .��5	      �  � RowDefinitions 5
   
   �� 5      $	��300 �6   6+   �� 5      $	��120 �6   6+   �� 5      $	��22* �6   6+   �� 5      $	��19* �6   6+    � ColumnDefinitions 5   
   �� 5      6"   �� 5      $��80 �6   6-   �� 5      $	��190 �6   6-   �� 5      $��80 �6   6-   �� 5      6"   .+�5   
   �� -   5         ��Name$ PlayNstopButton��5      $��4��6M   $��1��6]    �� 	IsDefault$
 True��6j    �� IsCancel$
 True��6{   $��60��5      $	��150��6   $��36(�5      $
��Bold"�6   $��10,60,90,83q�61   $��2��6F   
����������	#FFB4B4B4$��4,4,4,4q�6�   .��5      � $��5q�6    5      �� 5      5       .+�5"      �� -   5        	 ��Name$	 imageButton��5"      $��0��6.   $��Resources/play_icon.png��6;   6^   5#      5%      �� 5(   
   -   5        $ 
StopButton��5(      $��2��6B   $��4��6O   $��36(�6_   $
��Bold"�6m   $��10,24,90,24q�6   
�������$��4,4,4,4q�6�   ���	#FFB6B6B6.��5*      � $��5q�6    5+      �� 5,      5.      .+�50      �� -   5        $	 StopButtonImage��50      $��0��61   $��Resources/stop.png��6>   $��5,0,5,0q�6Z   6m   51      52      �� 53   
   -   5        
 ��Name$
 MusicListBox��53      $��3��6(   $��4��6<   
�������$��19(�54      $��0q�6   
���������55      �� 56       �� 
TargetType" ��6   .�57      ��  �� Property � �� �� Value$ 2q�6/   �� 58       � ��$ 3q�6<   6H   �� 59       � ��$ 4q�68   �� 5:       � ��
 �����64   �� 5;       � ��
 �����63   �� 5<       � �� �#21212163    �� Triggers 5=      P� 5>       P� Property �@��
IsSelected P� Value$
 True��68   . �5?      ��  � ��
 �   �6;   �� 5@       � ��$ 8q�68   6D   �� 5A       � ��
 �   �6;   �� 5B       � ��$ 4q�6@   �� 5C       � ��
 �����6<   5D      5F      5H      5J      5K      