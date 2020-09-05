;Defining Functions
(defun average-three (n1 n2 n3)
    (/ (+ n1 n2 n3) 3.0))

(format t "1. Average = ~a~%" (average-three 6 9 4))

;Data Types
(defvar x 10)
(defvar y 3.14159)
(defvar z 11.0E+4)
(defvar a NIL)

(format t "2. Type of x = ~a, Type of y = ~a, Type of z = ~a, Type of a = ~a" 
    (type-of x) (type-of y) (type-of z) (type-of a))

;Predicate Functions
(print (atom 'aabb))            
(print (equal 'a (car '(a r))))
(print (equal 1 1.0))   
(print (evenp 3))
(print (numberp 'ab10))
(print (zerop 0.0000001))
(print (> 6 3 2))   ;TRUE FOR DESCENDING ORDER
(print (< 5 3 1 2)) ;TRUE FOR ASCENDING ORDER
(print (listp '()))
(print (null '()))
(print (null NIL))

; COND
#| SYNTAX
(cond 
    (condition-1  return-value-1)
    (condition-2  return-value-2)
    (condition-3  return-value-3)
    (t  default-return-value)
)
|#

; GREATER OF TWO USING COND
(defun max-2 (a b)
    (cond
        ((> a b) a)
        (t b)
    )
)

; GREATER OF THREE USING COND
(defun max-3 (a b c)
    (cond
        ((> a b) 
            (cond
                ((> a c) a)
                (t c)
            )
        )
        ((> b c) b)
        (t c)
    )
)
(terpri) ;FOR NEW LINE



(princ "Hello")
(princ "World")



(prin1 "Hello")
(prin1 "World")



(print "Hello")
(print "World")




(defun my-union (list1 list2)
    (dolist (num list1)
        (if (null (member num list2))
                (setq list2 (cons num list2))
        )
    )
    list2
)

(print (my-union '(1 2 3 4 5 0) '(4 2 6 7 8)))

(defun my-intersection (list1 list2)
    (setq newList '())
    (dolist (num list1)
        (if (not (null (member num list2)))
            (setq newList (cons num newList))
        )
    )
    newList
)
(print (my-intersection '(1 2 3 4 5 0) '(4 2 6 7 8)))
