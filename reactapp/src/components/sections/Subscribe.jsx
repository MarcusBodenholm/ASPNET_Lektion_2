import React, {useState} from 'react'
import Arrows from "../../assets/images/Arrows.svg";

const Subscribe = () => {
    const [subscribeForm, setSubscribeForm] = useState({
        dailyNewsletter: false,
        advertisingUpdates: false,
        weekInReview: false,
        eventUpdates: false, 
        startupsWeekly: false, 
        podcasts: false
    });
    const [statusMessage, setStatusMessage] = useState("* Yes, I accept the user terms and privacy policy.");
    const [email, setEmail] = useState("");

    const handleOnChange = (e) => {
        const {name, value, type, checked} = e.target;
        const newValue = type === 'checkbox' ? checked : value;
        const newobject = {...subscribeForm, [name]: newValue};
        console.log(newobject);
        setSubscribeForm(current => ({...current, [name]: newValue}));
    }
    const handleSubscribe = async (e) => {
        e.preventDefault();
        const res = await fetch("https://localhost:7199/api/subscribe", {
          method: "post",
          headers: {
            'content-type': "application/json"
          },
          body: JSON.stringify({email: email, ...subscribeForm})
        })
        if (res.status === 200) 
        {
            setStatusMessage("You are subscribed.");
        }
        else {
            setStatusMessage("Something went wrong.");
        }
        setEmail("");
        
      }
    
    return (
        <section className='subscribe'>
            <div className='container'>
                <div className='title'>
                    <h1>Don&apos;t Want to Miss Anything?</h1>
                    <img src={Arrows} alt="Arrows" />
                </div>
                <form action="">
                    <div className='subscribe-options'>
                        <h5>
                            Sign up for Newsletters
                        </h5>
                        <div className='options'>
                            <div className='checkbox-group'>
                                <input checked={subscribeForm.dailyNewsletter} onChange={handleOnChange} type="checkbox" name="dailyNewsletter" />
                                <label htmlFor="">Daily Newsletter</label>
                            </div>
                            <div className='checkbox-group'>
                                <input checked={subscribeForm.advertisingUpdates} onChange={handleOnChange}  type="checkbox" name="advertisingUpdates" />
                                <label htmlFor="">Advertising Updates</label>
                            </div>
                            <div className='checkbox-group'>
                                <input checked={subscribeForm.weekInReview} onChange={handleOnChange}  type="checkbox" name="weekInReview" />
                                <label htmlFor="">Week in Review</label>
                            </div>
                            <div className='checkbox-group'>
                                <input checked={subscribeForm.eventUpdates} onChange={handleOnChange}  type="checkbox" name="eventUpdates" />
                                <label htmlFor="">Event Updates</label>
                            </div>
                            <div className='checkbox-group'>
                                <input checked={subscribeForm.startupsWeekly} onChange={handleOnChange}  type="checkbox" name="startupsWeekly" />
                                <label htmlFor="">Startups Weekly</label>
                            </div>
                            <div className='checkbox-group'>
                                <input checked={subscribeForm.podcasts} onChange={handleOnChange} type="checkbox" name="podcasts" />
                                <label htmlFor="">Podcasts</label>
                            </div>
                        </div>
                    </div>
                    <div className='subscribe-email'>
                        <i className='fa-regular fa-envelope'></i>
                        <input className='form-input' type="email" placeholder='Enter your email' value={email} onChange={(e) => setEmail(e.currentTarget.value)} />
                        <button className='btn btn-theme' type='submit' onClick={handleSubscribe}>Subscribe</button>
                    </div>
                    <p>
                        {statusMessage}
                    </p>
                </form>

            </div>
        </section>
    )
}

export default Subscribe