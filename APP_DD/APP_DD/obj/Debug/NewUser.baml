   M S B A M L   `   `   `  ����A  =APP_DD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:APP_DDAPP_DD  5   	       APP_DD.Regist   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:APP_DD     5   	     � Title$  Regist��5   	   $	��256��6   $	��300��6%    J� CommandBindings 5	      )  #System.Windows.Input.CommandBinding  5
   
   -   5           APP_DD.CustomCommands   LogIntoProgram   Command# Z 5
      6R    � 	Resources 5       �� 
TargetType �� Property �� Value �� 
TargetType	 �� CornerRadius
 ��Name��%�   '��       �� 5   
   " ��6   .�5      ��  � �� 5      �� 5      " ��6&   .R�5      �� #��z��6!   #��z��5      $	 5��5      ._�5      �� $
 PART_ContentHost��6+   5      5      5      5      5      .��5      � .+�5   
   �  � RowDefinitions 5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5       $
��Auto �6    �� 5!      .+�5#      �� $%��Регистрация/вход��6   $��Center=�6/   $��10q�6L   $��15(�6X   �� 5$      $��1��6    �� Orientation$ Vertical=�6&   $��Center=�6>   .+�5%      �� $��Логин:��6   $��Center=�6*   $��5q�6E   �� 5&      -   5         ��Name$ 
LogTextBox��5&      $	��200��6/   $��21��6;   5'      �� 5(      $��2��6   $ Vertical=�6&   $��10q�6=   $��Center=�6I   .+�5)      �� $��Email:��6   $��Center=�6*   $��5q�6E   �� 5*      -   5        $ EmailTextBox��5*      $	��200��61   $��22��6=   5+      �� 5,      $��3��6   $��Отправить��6#   $��90��67   $��25��6C   $)��#local:CustomCommands.LogIntoProgram��6O    5-      ��%^   '��       �� 5.      " ��6   .�5/      ��  �@��CornerRadius$ 5��69   50      51      52      53      54      55      