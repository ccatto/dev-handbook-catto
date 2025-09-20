# Quiz

# RxJS Observables: Question

**Which of the following is an incorrect statement regarding RxJS observables?**

- They are used by the HttpClient of Angular  
- They are a way to work with asynchronous data  
- ❌ They make our code synchronous  
- They are objects we subscribe to  

---

## Key Point
Observables are designed for **asynchronous** data handling, not synchronous execution.

## Summary
The incorrect statement is that observables make our code synchronous.

---

> 2 # RxJS Observables: Question

**When using RxJS Observables, what does the `.pipe()` method do?**

- ✅ It enables chaining multiple RxJS operators  
- It enables the use of Angular pipes with RxJS  
- It automatically subscribes and unsubscribes from an Observable  
- It turns an Observable into an Angular pipe  

---

## Key Point
`.pipe()` is used to **combine and chain multiple RxJS operators** on an observable stream.

## Summary
The `.pipe()` method allows chaining operators, not subscribing or turning observables into Angular pipes.


> 3 # RxJS Observables: Question

**What does the RxJS `map()` operator do?**

- Applies a given function to the source Observable, subscribes to it, and emits the resulting values as an Observable  
- Applies a given function to each value emitted by the source Observable, and returns the resulting values as an array  
- Applies a given function to each array emitted by the source Observable, and returns the resulting values as an Observable of arrays  
- ✅ Applies a given function to each value emitted by the source Observable, and emits the resulting values as an Observable  

---

## Key Point
The `map()` operator transforms **each value emitted** by an observable into a new value, emitting them as a new observable stream.

## Summary
`map()` applies a function to each emitted value and outputs the transformed values as a new observable.


---

> 4 # RxJS Observables: Question

**Which of the following is a common use case for `switchMap` in Angular?**

- ✅ Making HTTP requests based on user input, like searching or fetching data  
- Creating animations  
- Managing application state  
- Turning an Observable into a Signal  

---

## Key Point
`switchMap` is typically used when **new incoming events should cancel previous ones**, such as handling rapid user input with HTTP requests.

## Summary
A common use case for `switchMap` is making HTTP requests based on user input.  


