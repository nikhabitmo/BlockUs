# BlockUs
Реализовать простейший вариант игры «Блокус» средствами Windows Forms или WPF.
Реализуется классический вариант для двух игроков, каждый из которых выставляет фишки двух цветов на поле 20х20.
Цель игры – выставить как можно больше своих блоков и помешать противнику сделать то же самое. Победитель определяется по сумме очков своих выставленных блоков, на рисунке выше красные вместе синими побеждают желтых и зеленых.
Выбор блока для установки осуществлять с помощью мыши, ею же указываем начальное место для расположения. Далее блоки двигаются с помощью клавиш «Стрелки» на 1 клетку, способ управления вращением блоков определить самостоятельно. После установки блока в желаемую позицию ход фиксируется нажатием на «ENTER», при этом проверяется соответствие выбранной позиции правилам игры. При их нарушении выдается соответствующее сообщение, при этом ход не фиксируется и ошибку можно исправить.
Опционально можно реализовать отказ от установки выбранного блока и выбор для установки другого.
Состояние игры должно при завершении программы сохраняться в текстовый файл с возможностью ее продолжения с места завершения.
