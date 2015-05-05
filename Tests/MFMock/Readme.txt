The tests in this folder are noticeably lacking. This is because they are 
simply testing wrapper objects that do simple delegation to the concrete
IO objects in the Micro Framework. Since we intend these tests to run
in the emulator, since that is what MFUnit does, we can't directly
test real IO. If we ran on a board, we could for example connect and
ouput to an input, and verify the input changed. However, this would
necessitate anyone contributing to have a board and wire it 
accordingly. This would make contributing to this project suck, so
I chose not to do this. 

Realistically, the wrapper classes are very 
thin, and delegate very little. Visual inspection is sufficient. The
test methods are mostly here to make me feel better. And hopefully 
avoid at least some grief for anyone whom wants to flame me for
not being a TDD psycho on these particular classes. This is open
source folks. I'm trying to help out. If you want to complain, be
prepared to contribute and fix whatever you hate.