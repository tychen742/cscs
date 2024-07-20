.. index:: computer science

.. _computer_science:

Key Ideas in Computer Science
======================================= 

This book is an introduction to computer science, with a focus on 
the learning of computational concepts and problem-solving skills using the C# programming language. (v)

.. index:: IPO information processing model

The IPO Model
------------------------

The input–process–output (IPO) model is widely used in systems analysis 
and software engineering for describing the structure of an information processing 
task or process. Computers are used to process mathematical calculations, automate 
business decisions, and analyze textual data to generate language models, and so on. 
But in a computer system, these tasks all follow the same structure and go through the 
same stages. For example, when performing a Google search, you give an input to the 
search engine, Google processes it, and return back answers to you. 
That's what computer systems do: They take in information, process the information, 
and output the resulted outcome.


.. index:: programming

Programming Languages
---------------------------------

To learn a natural language, we may start with some basic words for daily usage. Similarly, when it 
comes to programming languages, we also start with the basic elements of programming such as how 
computers represents numbers, letters, words, and perform arithmetic operations. Next, we learn the 
vocabulary of programming, including terms like statement, operator, expression, value, and type [#f1]_. 
We then put the vocabulary together according to the *syntax* of a programming language to give 
instructions to the computers to do the work for us.

A computer program is a set of instructions (written in the specific notations specified by 
a programming language) given to computers. Interestingly, there are only a small number of ideas 
that we need to know when learning how to giving instructions to to computers, 
across probably all programming languages. Those basic constructs include:

- input
- output
- math
- sequence: instructions are executed one after another
- selection: decision-making; namely choosing between alternative paths of actions within a program
- iteration: repetition controlled by either count or condition 


.. index:: algorithms

Algorithms
------------

Computer science is a scientific discipline, so learning to program could mean learning a new way 
of thinking; as Allen Downey [#f1]_ puts it, to "think like a computer scientist." 
As Downey says, "this way of thinking combines some of the best features of mathematics, 
engineering, and natural science. Like mathematicians, computer scientists use formal languages to 
denote ideas – specifically computations. Like engineers, they design things, assembling components 
into systems and evaluating trade-offs among alternatives. Like scientists, they observe the 
behavior of complex systems, form hypotheses, and test predictions" [#f1]_.

For most learners, the idea central to computer science and information systems is problem solving, 
meaning "the ability to formulate problems, think creatively about solutions, and express a 
solution clearly and accurately." In computer science, the solutions to the problems are called *algorithms*, which is a list of step-by-step instructions, 
much like a recipe for cooking a dish, that will solve the problem under consideration if followed 
exactly [f#2]_. Programming is the process of implementing an algorithmic solution, using notations 
from a programming language, to create a computer program for us to solve the certain problem. 


.. index:: data representation

.. _data-representation:

Data Representation
---------------------


.. index:: bit
   byte
   binary number system
   base 2
   hexadecimal number sysetm

In modern electronic computers the most basic bit of data 
(actually called a *bit*) is held by two-state switches, often 
in the form of a higher voltage vs. a grounded state.  The symbolic representation
is often 0 vs. 1.  This symbolism comes from the representation of integers 
in *binary notation*, also called *base 2*:  
It is a place value system, but where each place
in a numeral is a 0 or a 1 and represents a power of two, so 1101 in binary 
can be viewed in our decimal system as
:math:`(1)2^3+(1)2^2+(0)2^1+(1)2^0=8+4+0+1=13`.

Computer hardware can only handle a limited number of bits at a time, 
and memory space is limited, so usually integers are stored in a limited
space, like 8, 16, 32 or 64 bits.  
We illustrate with the smallest, 8 bits, called a *byte*.  Since
each bit has two possible states, 8 bits have :math:`2^8=256` possible states.
Directly considered as binary numerals, they represent 0 through 
:math:`2^8-1=255`.

We also want to represent negative numbers, and have about half of the available
codes for them.  An 8-bit signed integer in *twos complement* notation
represents 0 through :math:`2^7-1` 
just as the unsigned numbers do.  These are all the 8-bit codes with a leading 0.
A negative number :math:`n` in the range :math:`-2^7=-128` through -1, 
is represented by what would be 
the unsigned notation for :math:`n+2^8`.  These will be all the 
8-bit codes with a leading 1.
For example -3 is represented like unsigned 256 - 3 = 253: 11111101 in binary.

.. index:: mantissa and exponent

Limited precision approximation of real numbers are stored in something like
scientific notation, except in binary,  roughly :math:`\pm(m)2^e`,
with a sign, mantissa m and exponent e. Both e and m have
fixed numbers of bits, so the limited options for the 
mantissa restricts the *precision* of the numbers, and the limited options
for the exponent restricts the *range*. Data on these limits for 
different sized numeric codes is in :ref:`value-types`.  

Once you have numbers, all sorts of other kinds of data can be encoded:  
Characters
like on your keyboard each have a numerical code associated with each one.  For
example the unicode for the letter A is 65.  Images are often 
represented as a sequence of colored pixels.  Since the human eye is only 
sensitive to three specific colors, red, green, and blue, 
a pixel is represented by a numerical intensity
for each of the three colors.

.. index:: instruction representation
   machine language
   assembler
   interpreter
   architecture
   

Programming Languages
--------------------------------

Machine instructions are very elementary, so programming
was still tedious, and code could not be reused on a 
machine with a different architecture.  

The next big step past assembler was the advent of
*high level* languages, with instructions more like normal mathematical or 
English expressions.  Examples are Fortran (1954) and Cobol (1959).  
A Fortran statement for calculating a slope like

.. code-block:: none

   S=(Y-V)/(X-U)

might require seven or or more machine code instructions. 

To use a Fortran program required three steps: write it (onto punch cards
originally), compile it to machine code, and execute the machine code.
The compiler would still be architecture specific, but the compiler for
an architecture would only need to be written once, and then any number of
programs could be compiled and run.

A later variant for executing a high-level language is
an *interpreter*.  An interpreter translates the high-level language
into machine code, and immediately executes it, not storing the
machine code for later
use, so every time a statement in the code is executed again,
the translation needs to be redone.  Interpreters are also 
machine-specific.

Some later languages like Java and C# use a hybrid approach: A compiler, 
that can run on any machine, does most of the work by 
translating the high-level language program
into a low-level *virtual machine*
language called a *bytecode*.  This is not the machine language for any real machine, 
but the bytecode is simple 
enough that writing an interpreter for it is very easy.  
Again the interpreter for the bytecode must be machine-specific.  
In this approach:

Program source => COMPILER => bytecode => INTERPRETER => execution

.. index:: program development cycle

Program Development Cycle
---------------------------


.. index:: computer science; key concepts

Key Computer Science Ideas
-----------------------------



.. index:: Denning - Peter
   Miles - Rob
   C# Yellow Book

A detailed discussion of these principles and the breadth of
importance of computer science can be found at
http://denninginstitute.com/pjd/GP/GP-site/welcome.html.  

For an alternate general introduction to programming and the context of C# in particular,
there is another free online source, 
Rob Miles'  
C# Yellow Book, available at
http://www.csharpcourse.com.
Note that it is written specifically for Microsoft Windows use, using 
Visual Studio software development environment, which works only on Windows machines,
and costs a lot if you are not a student.

The :ref:`lab-edit-compile-run` will introduce an alternative to the 
Microsoft environment: Xamarin Studio and Mono, which are free, 
open-source software projects that make C# available for multiple platforms:  
Windows, Mac, or Linux machines.  With a substantial fraction of students having their own
machine that does  *not* run Windows, this flexibility is important.


.. [#f1] Allen Downey (2022). Think Python: How to think like a computer scientist, 3rd edition. Green Tea Press. (CC BY-NC-SA 4.0)
.. [#f2] Brad Miller & David Ranum (2014). How to Think Like a Computer Scientist: Interactive Edition. (GNU FDL V.1.3)